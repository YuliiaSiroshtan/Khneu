using Planner.Data.GenericRepository;
using Planner.Entities.Domain.UniversityUnits;
using Planner.RepositoryInterfaces.ObjectInterfaces.UniversityUnits;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Data.Repository.UniversityUnits
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(string connectionString, string tableName) : base(connectionString, tableName)
        {
        }

        public async Task<IEnumerable<Department>> GetDepartments() 
            => await GetEntities();

        public async Task<Department> GetDepartmentById(int id) 
            => await GetEntityById(id);

        public async Task<Department> GetDepartmentByName(string name) 
            => await GetEntityByName(name);
    }
}
