using Planner.Data.BaseRepository;
using Planner.Data.Context;
using Planner.Entities.Domain;
using Planner.RepositoryInterfaces.ObjectInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace Planner.Data.Repository
{
    public class IndivPlanFieldsValueRepository : BaseRepository<IndivPlanFieldsValue>, IIndivPlanFieldsValueRepository
    {
        public IndivPlanFieldsValueRepository(AppDbContext _context) : base(_context)
        {

        }

        public void UpdateIndivPlanFieldValue(IndivPlanFieldsValue indivPlanFieldValue)
        {
            InsertOrUpdateGraph(indivPlanFieldValue);
        }

        public IEnumerable<IndivPlanFieldsValue> GetIndivPlanFieldValue(string userName)
        {
            yield return Query.Where(s => s.ApplicationUser.Email == userName).FirstOrDefault();
        }
    }
}
