using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppEntryLoad;
using System.Threading.Tasks;

namespace Planner.Data.Repository.AppEntryLoad
{
    public class HoursCalculationOfFirstSemesterRepository : GenericRepository<HoursCalculationOfFirstSemester>,
        IHoursCalculationOfFirstSemesterRepository
    {
        public HoursCalculationOfFirstSemesterRepository(string connectionString, string tableName) : base(
            connectionString, tableName) { }

        public async Task<int> InsertHoursCalculationOfFirstSemester(
            HoursCalculationOfFirstSemester hoursCalculationOfFirstSemester) =>
            await this.Insert(hoursCalculationOfFirstSemester);
    }
}