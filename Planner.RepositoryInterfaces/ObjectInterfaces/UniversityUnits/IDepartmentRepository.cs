using Planner.Entities.Domain.UniversityUnits;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces.UniversityUnits
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();

        Task DeleteDepartment(int id);

        Task<Department> GetDepartmentById(int id);

        Task<Department> GetDepartmentByName(string name);

        Task UpdateDepartment(Department department);

        Task<int> InsertDepartment(Department department);
    }
}
