using Planner.ServiceInterfaces.DTO.IndividualPlan;
using System.Collections.Generic;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface IIndividualPlanService
    {
        bool UpdateTrainingJob(TrainingJobDTO trainingJobDTO);
        IEnumerable<TrainingJobDTO> GetTrainingJob(string userName);
        bool UpdateIndivPlanFieldValue(IndivPlanFieldValueDTO indivPlanFieldValueDTO);
        IEnumerable<IndivPlanFieldValueDTO> GetIndivPlanFieldValue(string userName);
        IEnumerable<IndivPlanFieldDTO> GetIndivPlanField(string indPlanTypeId);

    }
}
