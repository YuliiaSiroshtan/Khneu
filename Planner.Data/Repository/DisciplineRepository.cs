using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.RepositoryInterfaces.ObjectInterfaces;

namespace Planner.Data.Repository
{
    public class DisciplineRepository : GenericRepository<Discipline>, IDisciplineRepository
    {
        public DisciplineRepository(string connectionString, string tableName) : base(connectionString, tableName)
        {
        }

        public async Task<IEnumerable<Discipline>> GetDisciplines() => await GetEntities();

        public async Task DeleteDiscipline(int id) => await DeleteEntity(id);

        public async Task<Discipline> GetDisciplineById(int id) => await GetEntityById(id);

        public async Task<Discipline> GetDisciplineByName(string name) => await GetEntityByName(name);

        public async Task UpdateDiscipline(Discipline discipline) => await Update(discipline);

        public async Task<int> InsertDiscipline(Discipline discipline) => await Insert(discipline);
    }
}
