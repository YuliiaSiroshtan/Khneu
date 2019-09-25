using Planner.Data.BaseRepository;
using Planner.Data.Context;
using Planner.Entities.Domain;
using Planner.RepositoryInterfaces.ObjectInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Planner.Data.Repository
{
    public class IndividualPlanFieldRepository : BaseRepository<IndivPlanFields>, IIndividualPlanFieldsRepository
    {
        public IndividualPlanFieldRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<IndivPlanFields>> GetIndivPlanField(string indPlanTypeId) => await Query
            .Where(s => s.IndPlanTypeId == indPlanTypeId).ToListAsync();
    }
}
