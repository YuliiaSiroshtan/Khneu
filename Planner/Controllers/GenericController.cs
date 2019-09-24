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
    public readonly IServiceFactory serviceFactory;
    public readonly IMapper _mapper;
    public GenericController(IServiceFactory _serviceFactory, IMapper mapper)
    {
      serviceFactory = _serviceFactory;
      _mapper = mapper;
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
      AuthenticationHeaderValue authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers[HeaderNames.Authorization]);
      ClaimsPrincipal claims = serviceFactory.TokenService.GetClaims(authenticationHeaderValue.Parameter);
      return claims;
    }
  }
}
