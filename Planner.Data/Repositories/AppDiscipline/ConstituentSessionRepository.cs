using Planner.Data.Repositories.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.RepositoryInterfaces.Interfaces.AppDiscipline;
using System.Threading.Tasks;

namespace Planner.Data.Repositories.AppDiscipline
{
    public class ConstituentSessionRepository : GenericRepository<ConstituentSession>, IConstituentSessionRepository
    {
        public ConstituentSessionRepository(string connectionString, string tableName) : base(connectionString,
            tableName) { }

        public async Task<int> InsertConstituentSession(ConstituentSession constituentSession) =>
            await this.Insert(constituentSession);
    }
}