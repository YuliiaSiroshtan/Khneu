using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.DTO;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface IFacultyService
    {
        Task<IEnumerable<FacultyDto>> GetFaculties();

        Task DeleteFaculty(int id);

        Task<FacultyDto> GetFacultyById(int id);

        Task<FacultyDto> GetFacultyByName(string name);

        Task UpdateFaculty(FacultyDto facultyDto);

        Task InsertFaculty(FacultyDto facultyDto);
    }
}
