using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppDiscipline;
using System.Threading.Tasks;

namespace Planner.Data.Repository.AppDiscipline
{
    public class SecondSemesterRepository : GenericRepository<SecondSemester>, ISecondSemesterRepository
    {
        public SecondSemesterRepository(string connectionString, string tableName) :
            base(connectionString, tableName) { }

        public async Task<int> InsertSecondSemester(SecondSemester secondSemester) => await this.Insert(secondSemester);
    }
}