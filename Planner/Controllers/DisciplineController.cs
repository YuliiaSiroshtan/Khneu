using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Planner.PresentationLayer.ViewModels;
using Planner.ServiceInterfaces.Interfaces;

namespace Planner.Controllers
{
  public class DisciplineController : GenericController
  {
    public DisciplineController(IServiceFactory serviceFactory, IMapper mapper) : base(serviceFactory, mapper)
    {
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetFullTimeDisciplines(int departmentId)
    {
      var disciplines = await ServiceFactory.DisciplineService.GetDisciplinesByDepartmentId(departmentId);
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
