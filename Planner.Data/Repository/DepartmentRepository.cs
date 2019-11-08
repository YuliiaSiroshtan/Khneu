using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.RepositoryInterfaces.ObjectInterfaces;

namespace Planner.Data.Repository
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(string connectionString, string tableName) : base(connectionString, tableName)
        {
        }

        public async Task<IEnumerable<Department>> GetDepartments() => await GetEntities();

        public async Task DeleteDepartment(int id) => await DeleteEntity(id);

        public async Task<Department> GetDepartmentById(int id) => await GetEntityById(id);

        public async Task<Department> GetDepartmentByName(string name) => await GetEntityByName(name);

        public async Task UpdateDepartment(Department department) => await Update(department);

        public async Task<int> InsertDepartment(Department department) => await Insert(department);
    }
}
