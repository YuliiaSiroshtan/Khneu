using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppSelectedDiscipline;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppSelectedDiscipline;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Data.Repository.AppSelectedDiscipline
{
    public class SelectedDisciplineRepository : GenericRepository<SelectedDiscipline>, ISelectedDisciplineRepository
    {
        public SelectedDisciplineRepository(string connectionString, string tableName) : base(connectionString,
            tableName) { }

        public async Task<IEnumerable<SelectedDiscipline>> GetSelectedDisciplines() => await this.GetEntities();

        public async Task DeleteSelectedDiscipline(int id) => await this.DeleteEntity(id);

        public async Task<SelectedDiscipline> GetSelectedDisciplineById(int id) => await this.GetEntityById(id);

        public async Task<SelectedDiscipline> GetSelectedDisciplineByName(string name) =>
            await this.GetEntityByName(name);

        public async Task UpdateSelectedDiscipline(SelectedDiscipline selectedDiscipline) =>
            await this.Update(selectedDiscipline);

        public async Task<int> InsertSelectedDiscipline(SelectedDiscipline selectedDiscipline) =>
            await this.Insert(selectedDiscipline);
    }
}