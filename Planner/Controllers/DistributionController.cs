using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Planner.DependencyInjection.ViewModels.Distribution;
using Planner.ServiceInterfaces.DTO.Distribution;
using Planner.ServiceInterfaces.Interfaces;
using System.Collections.Generic;

namespace Planner.Controllers
{
  [Route("api/Distribution")]
  public class DistributionController : GenericController
  {
    public DistributionController(IServiceFactory _serviceFactory, IMapper mapper) : base(_serviceFactory, mapper)
    {
    }

    [HttpPost]
    [Route("GetDayDistribution")]
    public IActionResult GetDayDistribution([FromBody] DistributionFilterViewModel distributionFilter)
    {
      IEnumerable<DayEntryDTO> result = serviceFactory.DistributionService.GetDayEntry(distributionFilter.Semester, distributionFilter.Year);
      return Ok(result);
    }
  }
}
