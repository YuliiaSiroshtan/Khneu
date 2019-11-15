using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppDiscipline;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Data.Repository.AppDiscipline
{
    public class ConstituentSessionRepository : GenericRepository<ConstituentSession>, IConstituentSessionRepository
    {
        public ConstituentSessionRepository(string connectionString, string tableName) : base(connectionString, tableName)
        {
        }

        public async Task<IEnumerable<ConstituentSession>> GetConstituentSessions() => await GetEntities();

        public async Task DeleteConstituentSession(int id) => await DeleteEntity(id);

        public async Task<ConstituentSession> GetConstituentSessionById(int id) => await GetEntityById(id);

        public async Task UpdateConstituentSession(ConstituentSession constituentSession) => await Update(constituentSession);

        public async Task<int> InsertConstituentSession(ConstituentSession constituentSession) => await Insert(constituentSession);
    }
}
