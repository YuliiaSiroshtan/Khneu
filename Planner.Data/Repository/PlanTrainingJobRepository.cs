using Planner.Data.BaseRepository;
using Planner.Data.Context;
using Planner.Entities.Domain;
using Planner.RepositoryInterfaces.ObjectInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace Planner.Data.Repository
{
    public class PlanTrainingJobRepository : BaseRepository<PlanTrainingJob>, IPlanTrainingRepository
    {
        public PlanTrainingJobRepository(AppDbContext _context) : base(_context)
        {
        }

        public void UpdateTrainingJob(PlanTrainingJob trainingJob)
        {
            InsertOrUpdateGraph(trainingJob);
        }

        public IEnumerable<PlanTrainingJob> GetTrainingJob(string userName)
        {
            yield return Query.Where(s => s.ApplicationUser.Email == userName).FirstOrDefault();
        }
    }
}
