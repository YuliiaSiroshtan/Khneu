using Planner.Entities.DTO.UniversityUnits;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.UniversityUnits
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetDepartments();

        Task<DepartmentDto> GetDepartmentById(int id);

        Task<DepartmentDto> GetDepartmentByName(string name);
    }
}