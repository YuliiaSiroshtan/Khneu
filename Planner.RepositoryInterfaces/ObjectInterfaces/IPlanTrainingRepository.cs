using Planner.Entities.Domain;
using System.Collections.Generic;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
{
    public interface IPlanTrainingRepository
    {
        void UpdateTrainingJob(PlanTrainingJob trainingJob);
        IEnumerable<PlanTrainingJob> GetTrainingJob(string userName);
    }
}
