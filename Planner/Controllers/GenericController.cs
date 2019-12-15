using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Planner.Entities;
using Planner.Entities.DTO.AppUserDto;
using Planner.ServiceInterfaces.Interfaces.Misc;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace Planner.Controllers
{
  public class GenericController : Controller
  {
    protected readonly IServiceScope ServiceScope;

    protected GenericController(IServiceScope serviceScope)
      => this.ServiceScope = serviceScope;

    [NonAction]
    protected UserClaimsDto UserInfo() =>
      new UserClaimsDto
      {
        Login = this.GetClaims().Identity.Name,
        Role = this.GetClaims().Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value
      };

    [NonAction]
    private ClaimsPrincipal GetClaims()
    {
      var authenticationHeaderValue = AuthenticationHeaderValue.Parse(this.Request.Headers[HeaderNames.Authorization]);
      var claims = this.ServiceScope.TokenService.GetClaims(authenticationHeaderValue.Parameter);

      return claims;
    }
  }
}
