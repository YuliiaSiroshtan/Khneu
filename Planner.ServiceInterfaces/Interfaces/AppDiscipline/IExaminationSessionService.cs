using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppDiscipline
{
    public interface IExaminationSessionService
    {
        Task<IEnumerable<ExaminationSessionDto>> GetExaminationSessions();

        Task DeleteExaminationSession(int id);

        Task<ExaminationSessionDto> GetExaminationSessionById(int id);

        Task UpdateExaminationSession(ExaminationSessionDto examinationSessionDto);

        Task<int> InsertExaminationSession(ExaminationSessionDto examinationSessionDto);
    }
}
