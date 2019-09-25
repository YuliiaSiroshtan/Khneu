using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Planner.DependencyInjection.ViewModels.Distribution;
using Planner.ServiceInterfaces.Interfaces;

namespace Planner.Controllers
{
  [Route("api/Distribution")]
  public class DistributionController : GenericController
  {
    public DistributionController(IServiceFactory serviceFactory, IMapper mapper) : base(serviceFactory, mapper)
    {
    }

    [HttpPost]
    [Route("GetDayDistribution")]
    public IActionResult GetDayDistribution([FromBody] DistributionFilterViewModel distributionFilter)
    {
      var result = ServiceFactory.DistributionService.GetDayEntry(distributionFilter.Semester, distributionFilter.Year);

      return Ok(result);
    }
  }
}
