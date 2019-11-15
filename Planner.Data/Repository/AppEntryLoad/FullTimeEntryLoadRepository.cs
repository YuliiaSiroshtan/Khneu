using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppEntryLoad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Data.Repository.AppEntryLoad
{
    public class FullTimeEntryLoadRepository : GenericRepository<FullTimeEntryLoad>, IFullTimeEntryLoadRepository
    {
        public FullTimeEntryLoadRepository(string connectionString, string tableName) : base(connectionString, tableName)
        {
        }

        public async Task<IEnumerable<FullTimeEntryLoad>> GetFullTimeEntryLoads() =>
            await GetEntities();

        public async Task DeleteFullTimeEntryLoad(int id) =>
            await DeleteEntity(id);

        public async Task<FullTimeEntryLoad> GetFullTimeEntryLoadById(int id) =>
            await GetEntityById(id);

        public async Task UpdateFullTimeEntryLoad(FullTimeEntryLoad fullTimeEntryLoad) =>
                await Update(fullTimeEntryLoad);

        public async Task<int> InsertFullTimeEntryLoad(FullTimeEntryLoad fullTimeEntryLoad) =>
            await Insert(fullTimeEntryLoad);
    }
}
