using Planner.Entities.Domain;
using Planner.Entities.Domain.AppIndividualPlan;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.Interfaces.AppIndividualPlan
{
    public interface IPlanTrainingRepository
    {
        //void UpdateTrainingJob(PlanTrainingJob trainingJob);
        
        Task<IEnumerable<PlanTrainingJob>> GetTrainingJob(string userName);
    }
}
