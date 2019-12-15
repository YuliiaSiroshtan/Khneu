using Microsoft.AspNetCore.Mvc;
using Planner.Entities.DTO.AppUserDto;
using Planner.ServiceInterfaces.Interfaces.Misc;
using System.Threading.Tasks;

namespace Planner.Controllers
{
  [Route("api/[controller]")]
  public class TokenController : GenericController
  {
    public TokenController(IServiceScope serviceScope) : base(serviceScope) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateToken([FromBody] UserLoginDto userLogin)
    {
      var result = await this.ServiceScope.TokenService.CreateJwtSecurityToken(userLogin.Login, userLogin.Password);

      return this.Ok(result);
    }
  }
}
