using Planner.Entities.DTO.AppIndividualPlanDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppIndividualPlan
{
    public interface IIndividualPlanService
    {
        Task UpdateTrainingJob(TrainingJobDTO trainingJobDTO);

        Task<IEnumerable<TrainingJobDTO>> GetTrainingJob(string userName);

        //bool UpdateIndivPlanFieldValue(IndivPlanFieldValueDTO indivPlanFieldValueDTO);

        Task<IEnumerable<IndivPlanFieldValueDTO>> GetIndivPlanFieldValue(string userName);
        Task<IEnumerable<IndivPlanFieldDTO>> GetIndivPlanField(string indPlanTypeId);
    }
}
