using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Planner.DependencyInjection.ViewModels.User;
using Planner.ServiceInterfaces.DTO;
using Planner.ServiceInterfaces.Interfaces;
using System.Collections.Generic;

namespace Planner.Controllers
{
  [Route("api/Ndr")]
  public class NdrController : GenericController
  {
    IHostingEnvironment hostingEnvironment;
    public NdrController(IServiceFactory _serviceFactory, IMapper mapper, IHostingEnvironment _hostingEnvironment) : base(_serviceFactory, mapper)
    {
      hostingEnvironment = _hostingEnvironment;
    }

    [HttpPost]
    [Route("AddNdr")]
    public IActionResult AddNdr([FromBody] NdrViewModel registerNdrDTO)
    {
      bool result = serviceFactory.NdrService.AddNdr(_mapper.Map<NdrDTO>(registerNdrDTO));
      return Ok(result);
    }

    [HttpGet]
    [Route("GetUserNdr")]
    public IActionResult GetUserNdr()
    {
      IEnumerable<NdrListDTO> ndrs = serviceFactory.NdrService.GetUserNdr(UserInfo().UserName);
      IEnumerable<NdrListViewModel> ndrModel = _mapper.Map<IEnumerable<NdrListViewModel>>(ndrs);
      return Ok(ndrModel);
    }
  }
}
