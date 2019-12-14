using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Planner.Entities.ConstNames;
using Planner.Entities.DTO.AppEntryLoadDto;
using Planner.Entities.DTO.AppUserDto;
using Planner.PresentationLayer.ViewModels;
using Planner.ServiceInterfaces.Interfaces.ServiceFactory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Controllers
{
  [Route("api/[controller]")]
  public class EntryLoadController : GenericController
  {
    private readonly IWebHostEnvironment _hostingEnvironment;

    public EntryLoadController(IServiceFactory serviceFactory,
      IMapper mapper,
      IWebHostEnvironment hostingEnvironment) : base(serviceFactory, mapper) =>
      this._hostingEnvironment = hostingEnvironment;


    [HttpGet("[action]")]
    public async Task<IActionResult> GetEntryLoadProperties()
    {
      var entryLoadsProperties = await this.ServiceFactory.EntryLoadPropertyService.GetEntryLoadsProperties();
      var entryLoadsPropertiesViewModel =
        this.Mapper.Map<IEnumerable<EntryLoadsPropertyViewModel>>(entryLoadsProperties);

      return this.Ok(entryLoadsPropertiesViewModel);
    }


    [HttpGet("[action]")]
    public async Task<IActionResult> GetUserEntryLoadPropertiesByUserId(int userId)
    {
      var entryLoadsProperties =
        await this.ServiceFactory.UserEntryLoadPropertyService.GetUserEntryLoadPropertiesByUserId(userId);
      var entryLoadsPropertiesViewModel =
        this.Mapper.Map<IEnumerable<UserEntryLoadsPropertyViewModel>>(entryLoadsProperties);

      return this.Ok(entryLoadsPropertiesViewModel);
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> MakeAnEntryLoadPlan(int userId)
    {
      var fullTimeEntryLoads = await this.ServiceFactory.FullTimeEntryLoadService.GetFullTimeEntryLoadsByUserId(userId);
      var partTimeEntryLoads = await this.ServiceFactory.PartTimeEntryLoadService.GetPartTimeEntryLoadsByUserId(userId);

      var fileName = $"{DateTime.Now.GetHashCode()}.xlsx";

      await this.InsertUserEntryLoadsPropertyData(userId, fileName);

      var path = Path.Combine(this._hostingEnvironment.WebRootPath, ExcelNames.FolderName,
        ExcelNames.BaseFileFolderName, ExcelNames.BaseExcelFile);

      this.ServiceFactory.ExcelService.Write(fullTimeEntryLoads, partTimeEntryLoads, path);

      path = Path.Combine(this._hostingEnvironment.WebRootPath, ExcelNames.FolderName,
        ExcelNames.UserEntryLoadFolderName, fileName);

      this.ServiceFactory.ExcelService.Save(path);

      return this.Ok(fileName);
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> UpdateEntryLoadFile(int id)
    {
      var entryLoadsProperty = await this.ChangeIsActiveEntryLoadsProperties(id);

      await this.ServiceFactory.EntryLoadPropertyService.RecreateTables();

      var path = Path.Combine(this._hostingEnvironment.WebRootPath, ExcelNames.FolderName, entryLoadsProperty.Name);

      await this.ServiceFactory.ExcelService.Read(path);

      return this.Ok(entryLoadsProperty);
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> DeleteEntryLoadFile(int id)
    {
      var entryLoadsProperty = await this.ServiceFactory.EntryLoadPropertyService.GetEntryLoadsPropertyById(id);

      var path = Path.Combine(this._hostingEnvironment.WebRootPath, ExcelNames.FolderName, entryLoadsProperty.Name);

      if (!System.IO.File.Exists(path)) return this.NotFound("Файл не знайдено");

      System.IO.File.Delete(path);
      await this.ServiceFactory.EntryLoadPropertyService.DeleteEntryLoadsProperty(id);

      return this.Ok("Файл видалено з серверу");
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> DeleteUserEntryLoadFile(int id)
    {
      var userEntryLoadProperty =
        await this.ServiceFactory.UserEntryLoadPropertyService.GetUserEntryLoadPropertyById(id);

      var path = Path.Combine(this._hostingEnvironment.WebRootPath, ExcelNames.FolderName,
        ExcelNames.UserEntryLoadFolderName, userEntryLoadProperty.Name);

      if (!System.IO.File.Exists(path)) return this.NotFound("Файл не знайдено");

      System.IO.File.Delete(path);
      await this.ServiceFactory.UserEntryLoadPropertyService.DeleteUserEntryLoadProperty(userEntryLoadProperty.Id);

      return this.Ok("Файл видалено з серверу");
    }


    [HttpGet("[action]")]
    public async Task<IActionResult> DownloadFile(int id)
    {
      var userEntryLoadsProperty =
        await this.ServiceFactory.UserEntryLoadPropertyService.GetUserEntryLoadPropertyById(id);

      var path = Path.Combine(this._hostingEnvironment.WebRootPath, ExcelNames.FolderName,
        ExcelNames.UserEntryLoadFolderName,
        userEntryLoadsProperty.Name);

      return this.PhysicalFile(path, ExcelNames.FileType, userEntryLoadsProperty.UserName);
    }


    [HttpPost]
    [Route("[action]")]
    [DisableRequestSizeLimit]
    public async Task<IActionResult> UploadFile([FromForm] FileInfoModel fileInfo)
    {
      var fileName = DateTime.Now.GetHashCode().ToString();

      try
      {
        var path = Path.Combine(this._hostingEnvironment.WebRootPath, ExcelNames.FolderName);

        if (!Directory.Exists(path)) Directory.CreateDirectory(path);

        if (fileInfo.File.Length > 0)
        {
          fileName += fileInfo.File.FileName;

          var fullPath = Path.Combine(path, fileName);

          await using var stream = new FileStream(fullPath, FileMode.Create);
          await fileInfo.File.CopyToAsync(stream);

          await this.InsertEntryLoadsPropertyData(fileInfo.HoursPerRate, fileName);

          return this.Json(fullPath);
        }
      }
      catch (Exception ex)
      {
        return this.BadRequest(ex.Message);
      }

      return this.BadRequest("Помилка завантаження файлу");
    }

    #region private methods

    private async Task<EntryLoadsPropertyDto> ChangeIsActiveEntryLoadsProperties(int id)
    {
      var entryLoadsProperties = await this.ServiceFactory.EntryLoadPropertyService.GetEntryLoadsProperties();

      var entryLoadsProperty = entryLoadsProperties.Single(x => x.Id == id);
      var entryLoadsPropertyIsActive = entryLoadsProperties.Single(x => x.IsActive);

      entryLoadsPropertyIsActive.IsActive = false;
      await this.ServiceFactory.EntryLoadPropertyService.UpdateEntryLoadsProperty(entryLoadsPropertyIsActive);

      entryLoadsProperty.IsActive = true;
      await this.ServiceFactory.EntryLoadPropertyService.UpdateEntryLoadsProperty(entryLoadsProperty);

      return entryLoadsProperty;
    }


    private async Task InsertEntryLoadsPropertyData(int hoursPerRate, string fileName) =>
      await this.ServiceFactory.EntryLoadPropertyService.InsertEntryLoadsProperty(new EntryLoadsPropertyDto
      {
        Name = fileName,
        DateTimeUpload = DateTime.Now,
        HoursPerRate = hoursPerRate,
        IsActive = false
      });


    private async Task InsertUserEntryLoadsPropertyData(int userId, string fileName) =>
      await this.ServiceFactory.UserEntryLoadPropertyService.InsertUserEntryLoadProperty(new UserEntryLoadPropertyDto
      {
        Name = fileName,
        UserId = userId,
        UserName = await this.ServiceFactory.UserService.GetUserNameById(userId),
        DateTimeUpload = DateTime.Now
      });

    #endregion
  }
}
