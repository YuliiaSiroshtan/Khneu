using Planner.Entities.DTO.UniversityUnits;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.UniversityUnits
{
    public interface IFacultyService
    {
        Task<IEnumerable<FacultyDto>> GetFaculties();

        Task<FacultyDto> GetFacultyById(int id);

        Task<FacultyDto> GetFacultyByName(string name);

    }
}
