using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Planner.DependencyInjection.ViewModels.IndividualPlan;
using Planner.ServiceInterfaces.DTO.IndividualPlan;
using Planner.ServiceInterfaces.Interfaces;
using System;
using System.Collections.Generic;

namespace Planner.Controllers
{
  [Route("api/IndividualPlan")]
  public class IndividualPlanController : GenericController
  {
    IHostingEnvironment hostingEnvironment;
    public IndividualPlanController(IServiceFactory _serviceFactory, IMapper mapper, IHostingEnvironment _hostingEnvironment) : base(_serviceFactory, mapper)
    {
      hostingEnvironment = _hostingEnvironment;
    }

    [HttpPost]
    [Route("UpdateTrainingJob")]
    public IActionResult UpdateTrainingJob([FromBody] TrainingJobViewModel trainingJobDTO)
    {
      Boolean result = serviceFactory.IndividualPlanService.UpdateTrainingJob(_mapper.Map<TrainingJobDTO>(trainingJobDTO));
      return Ok(result);
    }

    [HttpGet]
    [Route("GetTrainingJob")]
    public IActionResult GetTrainingJob()
    {
      IEnumerable<TrainingJobDTO> trainingJob = serviceFactory.IndividualPlanService.GetTrainingJob(UserInfo().UserName);
      IEnumerable<TrainingJobViewModel> trainingJobModel = _mapper.Map<IEnumerable<TrainingJobViewModel>>(trainingJob);
      return Ok(trainingJobModel);
    }

    [HttpPost]
    [Route("UpdateIndivPlanFieldValue")]
    public IActionResult UpdateIndivPlanFieldValue([FromBody] IndivPlanFieldValueViewModel indivPlanFieldValueDTO)
    {
      bool result = serviceFactory.IndividualPlanService.UpdateIndivPlanFieldValue(_mapper.Map<IndivPlanFieldValueDTO>(indivPlanFieldValueDTO));
      return Ok(result);
    }

    [HttpGet]
    [Route("GetIndivPlanFieldValue")]
    public IActionResult GetIndivPlanFieldValue()
    {
      IEnumerable<IndivPlanFieldValueDTO> indivPlanFieldValue = serviceFactory.IndividualPlanService.GetIndivPlanFieldValue(UserInfo().UserName);
      IEnumerable<IndivPlanFieldValueViewModel> indivPlanFieldValueModel = _mapper.Map<IEnumerable<IndivPlanFieldValueViewModel>>(indivPlanFieldValue);
      return Ok(indivPlanFieldValueModel);
    }

    [HttpGet]
    [Route("GetIndivPlanField")]
    public IActionResult GetIndivPlanField(string indPlanTypeId)
    {
      IEnumerable<IndivPlanFieldDTO> indivPlanField = serviceFactory.IndividualPlanService.GetIndivPlanField(indPlanTypeId);
      IEnumerable<IndivPlanFieldViewModel> indivPlanFieldModel = _mapper.Map<IEnumerable<IndivPlanFieldViewModel>>(indivPlanField);
      return Ok(indivPlanFieldModel);
    }
  }
}
