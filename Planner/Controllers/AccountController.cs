using Microsoft.AspNetCore.Mvc;
using Planner.Entities.DTO.AppUserDto;
using Planner.ServiceInterfaces.Interfaces.Misc;
using System.Threading.Tasks;

namespace Planner.Controllers
{
  [Route("api/[controller]")]
  public class AccountController : GenericController
  {
    public AccountController(IServiceScope serviceScope) : base(serviceScope) { }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetUsers()
      => this.Ok(await this.ServiceScope.UserService.GetUsers());

    [HttpGet("[action]")]
    public async Task<IActionResult> GetUsersByDepartmentId(int id)
      => this.Ok(await this.ServiceScope.UserService.GetUsersByDepartmentId(id));

    [HttpGet("[action]")]
    public async Task<IActionResult> GetUserInfo()
      => this.Ok(await this.ServiceScope.UserService.GetUserByLogin(this.UserInfo().Login));

    [HttpGet("[action]")]
    public async Task<IActionResult> GetUser(int id)
      => this.Ok(await this.ServiceScope.UserService.GetUserById(id));

    [HttpPost("[action]")]
    public async Task<IActionResult> UpdateUser([FromBody] UserDto userDto)
    {
      await this.ServiceScope.UserService.UpdateUser(userDto);

      return this.Ok(userDto);
    }
  }
}
