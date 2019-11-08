using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Planner.ServiceInterfaces.Interfaces;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Planner.Entities.DTO.AppUserDto;
using Planner.PresentationLayer.ViewModels;

namespace Planner.Controllers
{
  [Route("api/[controller]")]
  public class AccountController : GenericController
  {
    private readonly IWebHostEnvironment _hostingEnvironment;

    public AccountController(IServiceFactory serviceFactory,
      IMapper mapper,
      IWebHostEnvironment hostingEnvironment) : base(serviceFactory, mapper)
    {
      _hostingEnvironment = hostingEnvironment;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetUsers()
    {
      var users = await ServiceFactory.UserService.GetUsers();
      var usersViewModel = Mapper.Map<IEnumerable<UserViewModel>>(users);

      return Ok(usersViewModel);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetUserInfo()
    {
      var user = await ServiceFactory.UserService.GetUserByLogin(UserInfo().Login);
      var userInfo = Mapper.Map<UserViewModel>(user);

      return Ok(userInfo);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetUser(int userId)
    {
      var user = await ServiceFactory.UserService.GetUserById(userId);
      var userViewModel = Mapper.Map<UserViewModel>(user);

      return Ok(userViewModel);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> UpdateUser(UserViewModel userViewModel)
    {
      var user = Mapper.Map<UserDto>(userViewModel);
      await ServiceFactory.UserService.UpdateUser(user);

      return Ok(userViewModel);
    }

    [HttpPost, DisableRequestSizeLimit]
    public async Task<IActionResult> UploadFile()
    {
      const string folderName = "Images";
      var path = string.Empty;

      try
      {
        var file = Request.Form.Files[0];
        var newPath = Path.Combine(_hostingEnvironment.WebRootPath, folderName);

        if (!Directory.Exists(newPath))
        {
          Directory.CreateDirectory(newPath);
        }

        if (file.Length > 0)
        {
          var typeFile = file.ContentType.Split('/')[1];
          var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).Name
                           .TrimStart('"').Replace('"', '.') + typeFile;
          var fullPath = Path.Combine(newPath, fileName);

          if (System.IO.File.Exists(fullPath))
          {
            System.IO.File.Delete(fullPath);
          }

          await using var stream = new FileStream(fullPath, FileMode.Create);
          await file.CopyToAsync(stream);
          path = $"/{folderName}/{fileName}";

          return Json(path);
        }
      }
      catch (System.Exception ex)
      {
        return BadRequest(ex.Message);
      }

      return Json(path);
    }
  }
}
