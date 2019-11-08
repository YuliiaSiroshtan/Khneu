using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.DTO;

namespace Planner.ServiceInterfaces.Interfaces
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
