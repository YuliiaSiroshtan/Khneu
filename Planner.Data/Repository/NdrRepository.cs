using Planner.Data.BaseRepository;
using Planner.Data.Context;
using Planner.Entities.Domain;
using Planner.RepositoryInterfaces.ObjectInterfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Planner.Data.Repository
{
    public class NdrRepository : BaseRepository<NDR>, INdrRepository
    {
        public NdrRepository(AppDbContext context) : base(context)
        {
        }

        public void AddNdr(NDR ndr) => InsertOrUpdateGraph(ndr);


        public IEnumerable<NDR> GetUserNdr(string userName)
        {
            yield return Query.FirstOrDefault(s => s.User.Email == userName);
        }
    }
}
