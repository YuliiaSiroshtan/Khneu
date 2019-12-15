using Planner.Data.Repositories.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.RepositoryInterfaces.Interfaces.AppDiscipline;
using System.Threading.Tasks;

namespace Planner.Data.Repositories.AppDiscipline
{
    public class FirstSemesterRepository : GenericRepository<FirstSemester>, IFirstSemesterRepository
    {
        public FirstSemesterRepository(string connectionString, string tableName) :
            base(connectionString, tableName) { }

        public async Task<int> InsertFirstSemester(FirstSemester firstSemester) => await this.Insert(firstSemester);
    }
}