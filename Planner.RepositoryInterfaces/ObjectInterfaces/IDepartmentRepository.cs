using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.Domain.AppEntryLoad.FullTime;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
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
