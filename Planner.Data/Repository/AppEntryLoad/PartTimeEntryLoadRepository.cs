using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppEntryLoad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Data.Repository.AppEntryLoad
{
    public class PartTimeEntryLoadRepository : GenericRepository<PartTimeEntryLoad>, IPartTimeEntryLoadRepository
    {
        public PartTimeEntryLoadRepository(string connectionString, string tableName) : base(connectionString, tableName)
        {
        }

        public async Task<IEnumerable<PartTimeEntryLoad>> GetPartTimeEntryLoads() => await GetEntities();

        public async Task DeletePartTimeEntryLoad(int id) => await DeleteEntity(id);

        public async Task<PartTimeEntryLoad> GetPartTimeEntryLoadById(int id) => await GetEntityById(id);

        public async Task UpdatePartTimeEntryLoad(PartTimeEntryLoad partTimeEntryLoad) =>
            await Update(partTimeEntryLoad);

        public async Task<int> InsertPartTimeEntryLoad(PartTimeEntryLoad partTimeEntryLoad) =>
            await Insert(partTimeEntryLoad);
    }
}
