using Planner.Data.Repositories.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.RepositoryInterfaces.Interfaces.AppDiscipline;
using System.Threading.Tasks;

namespace Planner.Data.Repositories.AppDiscipline
{
    public class ExaminationSessionRepository : GenericRepository<ExaminationSession>, IExaminationSessionRepository
    {
        public ExaminationSessionRepository(string connectionString, string tableName) : base(connectionString,
            tableName) { }

        public async Task<int> InsertExaminationSession(ExaminationSession examinationSession) =>
            await this.Insert(examinationSession);
    }
}