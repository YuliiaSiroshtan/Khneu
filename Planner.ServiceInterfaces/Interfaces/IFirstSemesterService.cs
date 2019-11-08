using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.DTO;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface IFirstSemesterService
    {
        Task<IEnumerable<FirstSemesterDto>> GetFirstSemesters();

        Task DeleteFirstSemester(int id);

        Task<FirstSemesterDto> GetFirstSemesterById(int id);

        Task UpdateFirstSemester(FirstSemesterDto firstSemesterDto);

        Task<int> InsertFirstSemester(FirstSemesterDto firstSemesterDto);
    }
}
