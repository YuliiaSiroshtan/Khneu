using Planner.ServiceInterfaces.DTO.IndividualPlan;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface IIndividualPlanService
    {
        Task<bool> UpdateTrainingJob(TrainingJobDTO trainingJobDTO);
        IEnumerable<TrainingJobDTO> GetTrainingJob(string userName);
        Task<bool> UpdateIndivPlanFieldValue(IndivPlanFieldValueDTO indivPlanFieldValueDTO);
        IEnumerable<IndivPlanFieldValueDTO> GetIndivPlanFieldValue(string userName);
        IEnumerable<IndivPlanFieldDTO> GetIndivPlanField(string indPlanTypeId);

    }
}
