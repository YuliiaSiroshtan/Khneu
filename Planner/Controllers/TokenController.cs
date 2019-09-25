using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Planner.DependencyInjection.ViewModels.User;
using Planner.ServiceInterfaces.Interfaces;

namespace Planner.Controllers
{
  [Route("api/Token")]
  public class TokenController : GenericController
  {
    public TokenController(IServiceFactory serviceFactory, IMapper mapper) : base(serviceFactory, mapper)
    {
    }

    [HttpPost]
    [Route("CreateToken")]
    public async Task<IActionResult> CreateToken([FromBody] LoginViewModel login)
    {
      var result = await ServiceFactory.TokenService.CreatejwtSecurityToken(login.Email, login.Password);

      return Ok(result);
    }
  }
}
