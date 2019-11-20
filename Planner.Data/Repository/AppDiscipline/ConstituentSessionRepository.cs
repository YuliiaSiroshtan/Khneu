using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppDiscipline;
using System.Threading.Tasks;

namespace Planner.Data.Repository.AppDiscipline
{
    public class ConstituentSessionRepository : GenericRepository<ConstituentSession>, IConstituentSessionRepository
    {
        public ConstituentSessionRepository(string connectionString, string tableName) : base(connectionString, tableName)
        {
        }

        public async Task<int> InsertConstituentSession(ConstituentSession constituentSession) 
            => await Insert(constituentSession);
    }
}
