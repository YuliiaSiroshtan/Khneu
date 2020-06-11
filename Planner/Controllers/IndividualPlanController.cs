using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Planner.Entities.DTO.AppIndividualPlanDto;
using Planner.ServiceInterfaces.Interfaces.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Controllers
{
  [Route("api/[controller]")]
  public class IndividualPlanController : GenericController
  {
    private readonly IMapper _mapper;

    public IndividualPlanController(IServiceScope serviceScope, IMapper mapper) : base(serviceScope)
    {
      _mapper = mapper;
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetTrainingJob()
    {
      IEnumerable<TrainingJobDTO> trainingJob = await ServiceScope.IndividualPlanService.GetTrainingJob(UserInfo().Login); //.IndividualPlanService.GetTrainingJob(UserInfo().UserName);
      IEnumerable < TrainingJobDTO > trainingJobModel = _mapper.Map<IEnumerable<TrainingJobDTO>>(trainingJob);
      return Ok(trainingJobModel);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetIndivPlanFieldValue()
    {
      IEnumerable<IndivPlanFieldValueDTO> indivPlanFieldValue = await ServiceScope.IndividualPlanService.GetIndivPlanFieldValue(UserInfo().Login);
      IEnumerable<IndivPlanFieldValueDTO> indivPlanFieldValueModel = _mapper.Map<IEnumerable<IndivPlanFieldValueDTO>>(indivPlanFieldValue);
      return Ok(indivPlanFieldValueModel);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetIndivPlanField(string indPlanTypeId)
    {
      IEnumerable<IndivPlanFieldDTO> indivPlanField = await ServiceScope.IndividualPlanService.GetIndivPlanField(indPlanTypeId);
      IEnumerable<IndivPlanFieldDTO> indivPlanFieldModel = _mapper.Map<IEnumerable<IndivPlanFieldDTO>>(indivPlanField);
      return Ok(indivPlanFieldModel);
    }

  }
}
