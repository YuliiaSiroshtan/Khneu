using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.DTO;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetDepartments();

        Task DeleteDepartment(int id);

        Task<DepartmentDto> GetDepartmentById(int id);

        Task<DepartmentDto> GetDepartmentByName(string name);

        Task UpdateDepartment(DepartmentDto departmentDto);

        Task InsertDepartment(DepartmentDto departmentDto);
    }
}

