using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Planner.DependencyInjection.ViewModels.IndividualPlan;
using Planner.ServiceInterfaces.DTO.IndividualPlan;
using Planner.ServiceInterfaces.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Controllers
{
  [Route("api/IndividualPlan")]
  public class IndividualPlanController : GenericController
  {
    private readonly IHostingEnvironment _hostingEnvironment;
    public IndividualPlanController(IServiceFactory serviceFactory, IMapper mapper, IHostingEnvironment hostingEnvironment) : base(serviceFactory, mapper)
    {
      _hostingEnvironment = hostingEnvironment;
    }

    [HttpPost]
    [Route("UpdateTrainingJob")]
    public async Task<IActionResult> UpdateTrainingJob([FromBody] TrainingJobViewModel trainingJobDTO)
    {
      var result = await ServiceFactory.IndividualPlanService.UpdateTrainingJob(Mapper.Map<TrainingJobDTO>(trainingJobDTO));

      return Ok(result);
    }

    [HttpGet]
    [Route("GetTrainingJob")]
    public IActionResult GetTrainingJob()
    {
      var trainingJob = ServiceFactory.IndividualPlanService.GetTrainingJob(UserInfo().UserName);
      var trainingJobModel = Mapper.Map<IEnumerable<TrainingJobViewModel>>(trainingJob);

      return Ok(trainingJobModel);
    }

    [HttpPost]
    [Route("UpdateIndivPlanFieldValue")]
    public async Task<IActionResult> UpdateIndivPlanFieldValue([FromBody] IndivPlanFieldValueViewModel indivPlanFieldValueDTO)
    {
      var result = await ServiceFactory.IndividualPlanService.UpdateIndivPlanFieldValue(Mapper.Map<IndivPlanFieldValueDTO>(indivPlanFieldValueDTO));

      return Ok(result);
    }

    [HttpGet]
    [Route("GetIndivPlanFieldValue")]
    public IActionResult GetIndivPlanFieldValue()
    {
      var indivPlanFieldValue = ServiceFactory.IndividualPlanService.GetIndivPlanFieldValue(UserInfo().UserName);
      var indivPlanFieldValueModel = Mapper.Map<IEnumerable<IndivPlanFieldValueViewModel>>(indivPlanFieldValue);

      return Ok(indivPlanFieldValueModel);
    }

    [HttpGet]
    [Route("GetIndivPlanField")]
    public IActionResult GetIndivPlanField(string indPlanTypeId)
    {
      var indivPlanField = ServiceFactory.IndividualPlanService.GetIndivPlanField(indPlanTypeId);
      var indivPlanFieldModel = Mapper.Map<IEnumerable<IndivPlanFieldViewModel>>(indivPlanField);

      return Ok(indivPlanFieldModel);
    }
  }
}
