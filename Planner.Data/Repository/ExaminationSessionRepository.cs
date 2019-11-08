using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.RepositoryInterfaces.ObjectInterfaces;

namespace Planner.Data.Repository
{
    public class ExaminationSessionRepository:GenericRepository<ExaminationSession>, IExaminationSessionRepository
    {
        public ExaminationSessionRepository(string connectionString, string tableName) : base(connectionString, tableName)
        {
        }

        public async Task<IEnumerable<ExaminationSession>> GetExaminationSessions() => await GetEntities();

        public async Task DeleteExaminationSession(int id) => await DeleteEntity(id);

        public async Task<ExaminationSession> GetExaminationSessionById(int id) => await GetEntityById(id);

        public async Task UpdateExaminationSession(ExaminationSession examinationSession) =>
            await Update(examinationSession);

        public async Task<int> InsertExaminationSession(ExaminationSession examinationSession) =>
            await Insert(examinationSession);
    }
}
