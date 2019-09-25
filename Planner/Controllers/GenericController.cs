using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Planner.DependencyInjection.ViewModels.User;
using Planner.ServiceInterfaces.Interfaces;
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


    public UserClaimsViewModel UserInfo()
    {
      return new UserClaimsViewModel
      {
        UserName = GetClaims().Identity.Name,
        UserRole = GetClaims().Claims.Where(c => c.Type == ClaimTypes.Role).FirstOrDefault().Value
      };
    }

    private ClaimsPrincipal GetClaims()
    {
      var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers[HeaderNames.Authorization]);
      var claims = ServiceFactory.TokenService.GetClaims(authenticationHeaderValue.Parameter);

      return claims;
    }
  }
}
