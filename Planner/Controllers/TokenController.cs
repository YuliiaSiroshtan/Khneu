using Microsoft.AspNetCore.Mvc;
using Novell.Directory.Ldap;
using Planner.Entities.DTO.AppUserDto;
using Planner.Entities.JWT;
using Planner.ldap;
using Planner.ServiceInterfaces.Interfaces.Misc;
using System.Threading.Tasks;

namespace Planner.Controllers
{
  [Route("api/[controller]")]
  public class TokenController : GenericController
  {
    private ILdapConnection _conn;
    public TokenController(IServiceScope serviceScope) : base(serviceScope) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateToken([FromBody] UserLoginDto userLogin)
    {
      JwtResult result = await this.ServiceScope.TokenService.CreateJwtSecurityToken(userLogin.Login, userLogin.Password);

      //LdapRepository.GetUserByName("Сергій Петрович Євсеєв");
      //LdapRepository.GetFak();
      //LdapRepository.GetGroups();
      return this.Ok(result);
    }
  }
}
