using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Planner.DependencyInjection.ViewModels.User;
using Planner.ServiceInterfaces.DTO;
using Planner.ServiceInterfaces.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Controllers
{
  [Route("api/Ndr")]
  public class NdrController : GenericController
  {
    public NdrController(IServiceFactory serviceFactory, IMapper mapper) : base(serviceFactory, mapper)
    {
    }

    [HttpPost]
    [Route("AddNdr")]
    public async Task<IActionResult> AddNdr([FromBody] NdrViewModel registerNdrDTO)
    {
      var result = await ServiceFactory.NdrService.AddNdr(Mapper.Map<NdrDTO>(registerNdrDTO));

      return Ok(result);
    }

    [HttpGet]
    [Route("GetUserNdr")]
    public IActionResult GetUserNdr()
    {
      var ndrs = ServiceFactory.NdrService.GetUserNdr(UserInfo().UserName);
      var ndrModel = Mapper.Map<IEnumerable<NdrListViewModel>>(ndrs);

      return Ok(ndrModel);
    }
  }
}
