using AutoMapper;
using Planner.BusinessLogic.Services.Base;
using Planner.Entities.Domain.AppIndividualPlan;
using Planner.Entities.DTO.AppIndividualPlanDto;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces.AppIndividualPlan;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Services.AppIndividualPlan
{
    public class IndividualPlanService : BaseService, IIndividualPlanService
    {      
        public IndividualPlanService(IRepositoryScope repositoryScope, IMapper mapper) : base(repositoryScope, mapper) { }

        public async Task<IEnumerable<TrainingJobDTO>> GetTrainingJob(string userName)
        {
            IEnumerable<PlanTrainingJob> trainingJob = await RepositoryScope.PlanTrainingRepository.GetTrainingJob(userName);
            return Mapper.Map<IEnumerable<TrainingJobDTO>>(trainingJob);
        }

        public async Task<IEnumerable<IndivPlanFieldValueDTO>> GetIndivPlanFieldValue(string userName)
        {
            IEnumerable<IndivPlanFieldsValue> indivPlanFieldsValue = await RepositoryScope.IndivPlanFieldsValueRepository.GetIndivPlanFieldValue(userName);
            return Mapper.Map<IEnumerable<IndivPlanFieldValueDTO>>(indivPlanFieldsValue);
        }

        public async Task<IEnumerable<IndivPlanFieldDTO>> GetIndivPlanField(string indPlanTypeId)
        {
            IEnumerable<IndivPlanFields> indivPlanFields = await RepositoryScope.IndivPlanFieldsRepository.GetIndivPlanField(indPlanTypeId);
            return Mapper.Map<IEnumerable<IndivPlanFieldDTO>>(indivPlanFields);
        }

        public async Task UpdateTrainingJob(TrainingJobDTO trainingJobDTO)
        {
            PlanTrainingJob trainingJob = Mapper.Map<PlanTrainingJob>(trainingJobDTO);

            await RepositoryScope.PlanTrainingRepository.UpdateTrainingJob(trainingJob);
        }

        public async Task UpdateIndivPlanFieldValue(IndivPlanFieldValueDTO indivPlanFieldValueDTO)
        {
            IndivPlanFieldsValue indivPlanFieldsValue = Mapper.Map<IndivPlanFieldsValue>(indivPlanFieldValueDTO);
            
            await RepositoryScope.IndivPlanFieldsValueRepository.UpdateIndivPlanFieldValue(indivPlanFieldsValue);
        }
    }
}
