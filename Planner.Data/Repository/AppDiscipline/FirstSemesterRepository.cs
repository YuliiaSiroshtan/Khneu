using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppDiscipline;

namespace Planner.Data.Repository.AppDiscipline
{
    public class FirstSemesterRepository : GenericRepository<FirstSemester>, IFirstSemesterRepository
    {
        public FirstSemesterRepository(string connectionString, string tableName) : base(connectionString, tableName)
        {
        }

        public async Task<IEnumerable<FirstSemester>> GetFirstSemesters() => await GetEntities();

        public async Task DeleteFirstSemester(int id) => await DeleteEntity(id);

        public async Task<FirstSemester> GetFirstSemesterById(int id) => await GetEntityById(id);

        public async Task UpdateFirstSemester(FirstSemester firstSemester) => await Update(firstSemester);

        public async Task<int> InsertFirstSemester(FirstSemester firstSemester) => await Insert(firstSemester);
    }
}