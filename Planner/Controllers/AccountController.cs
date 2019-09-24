using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Planner.DependencyInjection.ViewModels.User;
using Planner.ServiceInterfaces.DTO;
using Planner.ServiceInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;

namespace Planner.Controllers
{
  [Route("api/Account")]
  public class AccountController : GenericController
  {
    IHostingEnvironment hostingEnvironment;
    public AccountController(IServiceFactory _serviceFactory, IMapper mapper, IHostingEnvironment _hostingEnvironment) : base(_serviceFactory, mapper)
    {
      hostingEnvironment = _hostingEnvironment;
    }

    [HttpGet]
    [Route("GetUserInfo")]
    public IActionResult GetUserInfo()
    {
      UserDTO user = serviceFactory.UserService.GetUser(UserInfo().UserName);
      UserInfoViewModel userInfo = _mapper.Map<UserInfoViewModel>(user);
      return Ok(userInfo);
    }

    [HttpGet]
    [Route("GetUser")]
    public IActionResult GetUser(String userId)
    {
      UserDTO user = serviceFactory.UserService.GetUserById(userId);
      UserInfoViewModel userInfo = _mapper.Map<UserInfoViewModel>(user);
      return Ok(userInfo);
    }


    [HttpPost]
    [Route("UpdateUser")]
    public IActionResult UpdateUser([FromBody] UserInfoViewModel registerUserDTO)
    {
      Boolean result = serviceFactory.UserService.AddOrUpdateUser(_mapper.Map<UserDTO>(registerUserDTO));
      return Ok(result);
    }

    [HttpGet]
    [Route("GetAllUsers")]
    public IActionResult GetAllUsers()
    {
      IEnumerable<UserListItemDTO> users = serviceFactory.UserService.GetAllUsers();
      IEnumerable<UserListItemViewModel> userModel = _mapper.Map<IEnumerable<UserListItemViewModel>>(users);
      return Ok(userModel);
    }


    [HttpPost, DisableRequestSizeLimit]
    public ActionResult UploadFile()
    {
      String fileName = "";
      IFormFile file = Request.Form.Files[0];
      String path = Path.Combine(hostingEnvironment.WebRootPath, "images", "profileImages");

      if (file.Length > 0)
      {
        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        string fullPath = Path.Combine(path, fileName);
        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
          file.CopyTo(stream);
        }
      }
      return Json(fileName);
    }

    [HttpPost]
    [Route("ChangeUserStatus")]
    public IActionResult ChangeUserStatus([FromBody] String userId)
    {
      Boolean result = serviceFactory.UserService.ChangeUserStatus(userId);
      return Ok(result);
    }

  }
}
