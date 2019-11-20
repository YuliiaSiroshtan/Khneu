using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppDiscipline;
using System.Threading.Tasks;

namespace Planner.Data.Repository.AppDiscipline
{
    public class ExaminationSessionRepository : GenericRepository<ExaminationSession>, IExaminationSessionRepository
    {
        public ExaminationSessionRepository(string connectionString, string tableName) : base(connectionString, tableName)
        {
        }

        public async Task<int> InsertExaminationSession(ExaminationSession examinationSession)
            => await Insert(examinationSession);
    }
}
