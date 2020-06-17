using Planner.Entities.DTO.AppIndividualPlanDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppIndividualPlan
{
    public interface IIndividualPlanService
    {
        Task<IEnumerable<TrainingJobDTO>> GetTrainingJob(string userName);
        Task<IEnumerable<IndivPlanFieldValueDTO>> GetIndivPlanFieldValue(string userName);
        Task<IEnumerable<IndivPlanFieldDTO>> GetIndivPlanField(string indPlanTypeId);
        Task UpdateTrainingJob(TrainingJobDTO trainingJobDTO);
        Task UpdateIndivPlanFieldValue(IndivPlanFieldValueDTO indivPlanFieldValueDTO);
    }
}
