using Planner.Data.Repositories.GenericRepository;
using Planner.Entities.Domain.AppSelectedDiscipline;
using Planner.RepositoryInterfaces.Interfaces.AppSelectedDiscipline;
using System.Threading.Tasks;

namespace Planner.Data.Repositories.AppEntryLoad
{
    public class PracticalRepository : GenericRepository<Practical>, IPracticalRepository
    {
        public PracticalRepository(string connectionString, string tableName) : base(connectionString, tableName) { }

        public async Task<int> InsertPractical(Practical practical) => await this.Insert(practical);
    }
}