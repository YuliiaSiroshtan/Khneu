using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Planner.PresentationLayer.ViewModels;
using Planner.ServiceInterfaces.Interfaces.ServiceFactory;
using System.Threading.Tasks;

namespace Planner.Controllers
{
  [Route("api/[controller]")]
  public class TokenController : GenericController
  {
    public TokenController(IServiceFactory serviceFactory, IMapper mapper) : base(serviceFactory, mapper)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateToken([FromBody] LoginViewModel login)
    {
      var result = await ServiceFactory.TokenService.CreateJwtSecurityToken(login.Login, login.Password);

      return Ok(result);
    }
  }
}
