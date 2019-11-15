using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppDiscipline
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
