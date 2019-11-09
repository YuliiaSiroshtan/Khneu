using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Planner.ServiceInterfaces.Interfaces;
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
    public async Task<IActionResult> UpdateUser([FromBody] UserViewModel userViewModel)
    {
      var user = Mapper.Map<UserDto>(userViewModel);
      await ServiceFactory.UserService.UpdateUser(user);

      return Ok(userViewModel);
    }
  }
}
