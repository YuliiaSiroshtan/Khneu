using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Planner.Entities.DTO.AppUserDto;
using Planner.PresentationLayer.ViewModels;
using Planner.ServiceInterfaces.Interfaces.ServiceFactory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Controllers
{
  [Route("api/[controller]")]
  public class AccountController : GenericController
  {
    public AccountController(IServiceFactory serviceFactory, IMapper mapper) : base(serviceFactory, mapper) { }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetUsers()
    {
      var users = await this.ServiceFactory.UserService.GetUsers();
      var usersViewModel = this.Mapper.Map<IEnumerable<UserViewModel>>(users);

      return this.Ok(usersViewModel);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetUsersByDepartmentId(int id)
    {
      var users = await this.ServiceFactory.UserService.GetUsersByDepartmentId(id);
      var usersViewModel = this.Mapper.Map<IEnumerable<UserViewModel>>(users);

      return this.Ok(usersViewModel);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetUserInfo()
    {
      var user = await this.ServiceFactory.UserService.GetUserByLogin(this.UserInfo().Login);
      var userInfo = this.Mapper.Map<UserViewModel>(user);

      return this.Ok(userInfo);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetUser(int id)
    {
      var user = await this.ServiceFactory.UserService.GetUserById(id);
      var userViewModel = this.Mapper.Map<UserViewModel>(user);

      return this.Ok(userViewModel);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> UpdateUser([FromBody] UserViewModel userViewModel)
    {
      var user = this.Mapper.Map<UserDto>(userViewModel);
      await this.ServiceFactory.UserService.UpdateUser(user);

      return this.Ok(userViewModel);
    }
  }
}
