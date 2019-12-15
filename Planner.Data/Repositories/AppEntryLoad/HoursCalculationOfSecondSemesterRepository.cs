using Planner.Data.Repositories.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.RepositoryInterfaces.Interfaces.AppEntryLoad;
using System.Threading.Tasks;

namespace Planner.Data.Repositories.AppEntryLoad
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