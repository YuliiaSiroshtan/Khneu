using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.RepositoryInterfaces.ObjectInterfaces;

namespace Planner.Data.Repository
{
    public class SelectedDisciplineRepository : GenericRepository<SelectedDiscipline>, ISelectedDisciplineRepository
    {
        public SelectedDisciplineRepository(string connectionString, string tableName) : base(connectionString, tableName)
        {
        }

        public async Task<IEnumerable<SelectedDiscipline>> GetSelectedDisciplines() => await GetEntities();

        public async Task DeleteSelectedDiscipline(int id) => await DeleteEntity(id);

        public async Task<SelectedDiscipline> GetSelectedDisciplineById(int id) => await GetEntityById(id);

        public async Task<SelectedDiscipline> GetSelectedDisciplineByName(string name) => await GetEntityByName(name);

        public async Task UpdateSelectedDiscipline(SelectedDiscipline selectedDiscipline) =>
            await Update(selectedDiscipline);

        public async Task<int> InsertSelectedDiscipline(SelectedDiscipline selectedDiscipline) =>
            await Insert(selectedDiscipline);

    }
}
