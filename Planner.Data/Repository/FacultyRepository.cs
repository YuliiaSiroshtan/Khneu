using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.RepositoryInterfaces.ObjectInterfaces;

namespace Planner.Data.Repository
{
    public class FacultyRepository : GenericRepository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(string connectionString, string tableName) : base(connectionString, tableName)
        {
        }

        public async Task<IEnumerable<Faculty>> GetFaculties() => await GetEntities();

        public async Task DeleteFaculty(int id) => await DeleteEntity(id);

        public async Task<Faculty> GetFacultyById(int id) => await GetEntityById(id);

        public async Task<Faculty> GetFacultyByName(string name) => await GetEntityByName(name);

        public async Task UpdateFaculty(Faculty faculty) => await Update(faculty);

        public async Task<int> InsertFaculty(Faculty faculty) => await Insert(faculty);
    }
}
