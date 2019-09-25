using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Planner.DependencyInjection.ViewModels.User;
using Planner.ServiceInterfaces.DTO;
using Planner.ServiceInterfaces.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Planner.Controllers
{
  [Route("api/Account")]
  public class AccountController : GenericController
  {
    private readonly IHostingEnvironment _hostingEnvironment;

    public AccountController(IServiceFactory serviceFactory,
      IMapper mapper,
      IHostingEnvironment hostingEnvironment) : base(serviceFactory, mapper)
    {
      _hostingEnvironment = hostingEnvironment;
    }

    [HttpGet]
    [Route("GetUserInfo")]
    public async Task<IActionResult> GetUserInfo()
    {
      var user = await ServiceFactory.UserService.GetUser(UserInfo().UserName);
      var userInfo = Mapper.Map<UserInfoViewModel>(user);

      return Ok(userInfo);
    }

    [HttpGet]
    [Route("GetUser")]
    public async Task<IActionResult> GetUser(string userId)
    {
      var user = await ServiceFactory.UserService.GetUserById(userId);
      var userInfo = Mapper.Map<UserInfoViewModel>(user);

      return Ok(userInfo);
    }


    [HttpPost]
    [Route("UpdateUser")]
    public async Task<IActionResult> UpdateUser([FromBody] UserInfoViewModel registerUserDTO)
    {
      var result = await ServiceFactory.UserService.AddOrUpdateUser(Mapper.Map<UserDTO>(registerUserDTO));

      return Ok(result);
    }

    [HttpGet]
    [Route("GetAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
      var users = await ServiceFactory.UserService.GetAllUsers();
      var userModel = Mapper.Map<IEnumerable<UserListItemViewModel>>(users);

      return Ok(userModel);
    }


    [HttpPost, DisableRequestSizeLimit]
    public IActionResult UploadFile()
    {
      var fileName = "";
      var file = Request.Form.Files[0];
      var path = Path.Combine(_hostingEnvironment.WebRootPath, "images", "profileImages");

      if (file.Length <= 0) return Json(fileName);

      fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
      var fullPath = Path.Combine(path, fileName);

      using (var stream = new FileStream(fullPath, FileMode.Create))
      {
        file.CopyTo(stream);
      }

      return Json(fileName);
    }

    [HttpPost]
    [Route("ChangeUserStatus")]
    public async Task<IActionResult> ChangeUserStatus([FromBody] string userId)
    {
      var result = await ServiceFactory.UserService.ChangeUserStatus(userId);

      return Ok(result);
    }

  }
}
