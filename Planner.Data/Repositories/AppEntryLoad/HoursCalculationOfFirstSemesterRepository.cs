using Planner.Data.Repositories.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.RepositoryInterfaces.Interfaces.AppEntryLoad;
using System.Threading.Tasks;

namespace Planner.Data.Repositories.AppEntryLoad
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