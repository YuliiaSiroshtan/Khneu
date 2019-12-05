using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppSelectedDiscipline;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppSelectedDiscipline;
using System.Threading.Tasks;

namespace Planner.Data.Repository.AppEntryLoad
{
    public class PracticalRepository : GenericRepository<Practical>, IPracticalRepository
    {
        public PracticalRepository(string connectionString, string tableName) : base(connectionString, tableName) { }

        public async Task<int> InsertPractical(Practical practical) => await this.Insert(practical);
    }
}