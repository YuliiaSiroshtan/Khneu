using Planner.Data.GenericRepository;
using Planner.Entities.Domain.UniversityUnits;
using Planner.RepositoryInterfaces.ObjectInterfaces.UniversityUnits;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Data.Repository.UniversityUnits
{
    public class FacultyRepository : GenericRepository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(string connectionString, string tableName) : base(connectionString, tableName)
        {
        }

        public async Task<IEnumerable<Faculty>> GetFaculties() 
            => await GetEntities();

        public async Task<Faculty> GetFacultyById(int id) 
            => await GetEntityById(id);

        public async Task<Faculty> GetFacultyByName(string name) 
            => await GetEntityByName(name);

    }
}
