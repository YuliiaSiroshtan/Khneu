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
    public AccountController(IServiceFactory serviceFactory, IMapper mapper) : base(serviceFactory, mapper)
    {
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetUsers()
    {
      var users = await ServiceFactory.UserService.GetUsers();
      var usersViewModel = Mapper.Map<IEnumerable<UserViewModel>>(users);

      return Ok(usersViewModel);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetUsersByDepartmentId(int id)
    {
      var users = await ServiceFactory.UserService.GetUsersByDepartmentId(id);
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
    public async Task<IActionResult> GetUser(int id)
    {
      var user = await ServiceFactory.UserService.GetUserById(id);
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
