using Microsoft.AspNetCore.Mvc;
using Planner.ServiceInterfaces.Interfaces.Misc;
using System.Threading.Tasks;

namespace Planner.Controllers
{
  [Route("api/[controller]")]
  public class DisciplineController : GenericController
  {
    public DisciplineController(IServiceScope serviceScope) : base(serviceScope) { }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetFullTimeDisciplines(int departmentId)
      => this.Ok(await this.ServiceScope.FullTimeDisciplineService.GetFullTimeDisciplinesByDepartmentId(departmentId));

    [HttpGet("[action]")]
    public async Task<IActionResult> GetPartTimeDisciplines(int departmentId)
      => this.Ok(await this.ServiceScope.PartTimeDisciplineService.GetPartTimeDisciplinesByDepartmentId(departmentId));
  }
}
