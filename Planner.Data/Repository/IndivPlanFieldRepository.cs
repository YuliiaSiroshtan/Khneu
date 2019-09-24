using Planner.Data.BaseRepository;
using Planner.Data.Context;
using Planner.Entities.Domain;
using Planner.RepositoryInterfaces.ObjectInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace Planner.Data.Repository
{
    public class IndivPlanFieldRepository : BaseRepository<IndivPlanFields>, IIndivPlanFieldsRepository
    {
        public IndivPlanFieldRepository(AppDbContext _context) : base(_context)
        {

        }

        public IEnumerable<IndivPlanFields> GetIndivPlanField(string indPlanTypeId)
        {
            return Query.Where(s => s.IndPlanTypeId == indPlanTypeId).ToList();
        }
    }
}
