using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.RepositoryInterfaces.ObjectInterfaces;

namespace Planner.Data.Repository
{
    public class PartTimeDisciplineRepository: GenericRepository<PartTimeDiscipline>, IPartTimeDisciplineRepository
    {
        public PartTimeDisciplineRepository(string connectionString, string tableName) : base(connectionString, tableName)
        {
        }

        public async Task<IEnumerable<PartTimeDiscipline>> GetPartTimeDisciplines() => await GetEntities();

        public async Task DeletePartTimeDiscipline(int id) => await DeleteEntity(id);

        public async Task<PartTimeDiscipline> GetPartTimeDisciplineById(int id) => await GetEntityById(id);

        public async Task<PartTimeDiscipline> GetPartTimeDisciplineByName(string name) => await GetEntityByName(name);

        public async Task UpdatePartTimeDiscipline(PartTimeDiscipline partTimeDiscipline) =>
            await Update(partTimeDiscipline);

        public async Task<int> InsertPartTimeDiscipline(PartTimeDiscipline partTimeDiscipline) =>
            await Insert(partTimeDiscipline);
    }
}
