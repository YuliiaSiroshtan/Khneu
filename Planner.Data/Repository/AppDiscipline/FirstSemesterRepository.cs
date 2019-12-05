using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppDiscipline;
using System.Threading.Tasks;

namespace Planner.Data.Repository.AppDiscipline
{
    public class FirstSemesterRepository : GenericRepository<FirstSemester>, IFirstSemesterRepository
    {
        public FirstSemesterRepository(string connectionString, string tableName) :
            base(connectionString, tableName) { }

        public async Task<int> InsertFirstSemester(FirstSemester firstSemester) => await this.Insert(firstSemester);
    }
}