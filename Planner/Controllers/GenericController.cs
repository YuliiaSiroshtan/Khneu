using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Planner.PresentationLayer.ViewModels;
using Planner.ServiceInterfaces.Interfaces.ServiceFactory;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace Planner.Controllers
{
  public class GenericController : Controller
  {
    protected readonly IMapper Mapper;
    protected readonly IServiceFactory ServiceFactory;

    protected GenericController(IServiceFactory serviceFactory, IMapper mapper)
    {
      this.ServiceFactory = serviceFactory;
      this.Mapper = mapper;
    }

    [NonAction]
    protected UserClaimsViewModel UserInfo() =>
      new UserClaimsViewModel
      {
        Login = this.GetClaims().Identity.Name,
        Role = this.GetClaims().Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value
      };

    [NonAction]
    private ClaimsPrincipal GetClaims()
    {
      var authenticationHeaderValue = AuthenticationHeaderValue.Parse(this.Request.Headers[HeaderNames.Authorization]);
      var claims = this.ServiceFactory.TokenService.GetClaims(authenticationHeaderValue.Parameter);

      return claims;
    }
  }
}
