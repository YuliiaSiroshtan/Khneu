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
    private readonly IHostingEnvironment _hostingEnvironment;
    public NdrController(IServiceFactory serviceFactory, IMapper mapper, IHostingEnvironment hostingEnvironment) : base(serviceFactory, mapper)
    {
      _hostingEnvironment = hostingEnvironment;
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
    public async Task<IActionResult> GetUserNdr()
    {
      var ndrs = await ServiceFactory.NdrService.GetUserNdr(UserInfo().UserName);
      var ndrModel = Mapper.Map<IEnumerable<NdrListViewModel>>(ndrs);

      return Ok(ndrModel);
    }
  }
}
