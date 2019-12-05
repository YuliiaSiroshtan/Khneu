using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppEntryLoad;
using System.Threading.Tasks;

namespace Planner.Data.Repository.AppEntryLoad
{
    public class HoursCalculationOfSecondSemesterRepository : GenericRepository<HoursCalculationOfSecondSemester>,
        IHoursCalculationOfSecondSemesterRepository
    {
        public HoursCalculationOfSecondSemesterRepository(string connectionString, string tableName) : base(
            connectionString, tableName) { }

        public async Task<int> InsertHoursCalculationOfSecondSemester(
            HoursCalculationOfSecondSemester hoursCalculationOfSecondSemester) =>
            await this.Insert(hoursCalculationOfSecondSemester);
    }
}