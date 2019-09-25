using System.Collections.Generic;
using System.Linq;
using Planner.Data.BaseRepository;
using Planner.Data.Context;
using Planner.Entities.Domain;
using Planner.RepositoryInterfaces.ObjectInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Planner.Data.Repository
{
    public class IndividualPlanFieldsValueRepository : BaseRepository<IndivPlanFieldsValue>, IIndividualPlanFieldsValueRepository
    {
        public IndividualPlanFieldsValueRepository(AppDbContext context) : base(context)
        {

        }

        public void UpdateIndividualPlanFieldValue(IndivPlanFieldsValue indivPlanFieldValue) => InsertOrUpdateGraph(indivPlanFieldValue);

        public IEnumerable<IndivPlanFieldsValue> GetIndividualPlanFieldValue(string userName)
        {
            yield return Query.FirstOrDefault(s => s.ApplicationUser.Email == userName);
        }
    }
}
