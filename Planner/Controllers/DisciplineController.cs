using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Planner.PresentationLayer.ViewModels;
using Planner.ServiceInterfaces.Interfaces.ServiceFactory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Controllers
{
  [Route("api/[controller]")]
  public class DisciplineController : GenericController
  {
    public DisciplineController(IServiceFactory serviceFactory, IMapper mapper) : base(serviceFactory, mapper)
    {
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetFullTimeDisciplines(int departmentId)
    {
      var disciplines = await ServiceFactory.FullTimeDisciplineService.GetFullTimeDisciplinesByDepartmentId(departmentId);
      var disciplinesViewModel = Mapper.Map<IEnumerable<FullTimeDisciplinesViewModel>>(disciplines);

      return Ok(disciplinesViewModel);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetPartTimeDisciplines(int departmentId)
    {
      var disciplines = await ServiceFactory.PartTimeDisciplineService.GetPartTimeDisciplinesByDepartmentId(departmentId);
      var disciplinesViewModel = Mapper.Map<IEnumerable<PartTimeDisciplineViewModel>>(disciplines);

      return Ok(disciplinesViewModel);
    }
  }
}
