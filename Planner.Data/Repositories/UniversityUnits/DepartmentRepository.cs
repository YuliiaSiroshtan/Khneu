using Planner.Data.Repositories.GenericRepository;
using Planner.Entities.Domain.UniversityUnits;
using Planner.RepositoryInterfaces.Interfaces.UniversityUnits;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Data.Repositories.UniversityUnits
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(string connectionString, string tableName) : base(connectionString, tableName) { }

        public async Task<IEnumerable<Department>> GetDepartments() => await this.GetEntities();

        public async Task<Department> GetDepartmentById(int id) => await this.GetEntityById(id);

        public async Task<Department> GetDepartmentByName(string name) => await this.GetEntityByName(name);
    }
}