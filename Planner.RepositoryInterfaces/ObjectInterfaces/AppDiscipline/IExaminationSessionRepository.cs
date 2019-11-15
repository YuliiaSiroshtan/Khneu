using Planner.Entities.Domain.AppEntryLoad.PartTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces.AppDiscipline
{
    public interface IExaminationSessionRepository
    {
        Task<IEnumerable<ExaminationSession>> GetExaminationSessions();

        Task DeleteExaminationSession(int id);

        Task<ExaminationSession> GetExaminationSessionById(int id);

        Task UpdateExaminationSession(ExaminationSession examinationSession);

        Task<int> InsertExaminationSession(ExaminationSession examinationSession);
    }
}
