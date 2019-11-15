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
    protected readonly IServiceFactory ServiceFactory;

    protected readonly IMapper Mapper;

    public GenericController(IServiceFactory serviceFactory, IMapper mapper)
    {
      ServiceFactory = serviceFactory;
      Mapper = mapper;
    }

    [NonAction]
    protected UserClaimsViewModel UserInfo()
    {
      return new UserClaimsViewModel
      {
        Login = GetClaims().Identity.Name,
        Role = GetClaims().Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value
      };
    }

    [NonAction]
    private ClaimsPrincipal GetClaims()
    {
      var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers[HeaderNames.Authorization]);
      var claims = ServiceFactory.TokenService.GetClaims(authenticationHeaderValue.Parameter);

      return claims;
    }
  }
}
