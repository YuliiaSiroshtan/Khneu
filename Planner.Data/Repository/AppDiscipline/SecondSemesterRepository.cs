using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppDiscipline;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Data.Repository.AppDiscipline
{
    public class SecondSemesterRepository : GenericRepository<SecondSemester>, ISecondSemesterRepository
    {
        public SecondSemesterRepository(string connectionString, string tableName) : base(connectionString, tableName)
        {
        }

        public async Task<IEnumerable<SecondSemester>> GetSecondSemesters() => await GetEntities();

        public async Task DeleteSecondSemester(int id) => await DeleteEntity(id);

        public async Task<SecondSemester> GetSecondSemesterById(int id) => await GetEntityById(id);

        public async Task UpdateSecondSemester(SecondSemester secondSemester) => await Update(secondSemester);

        public async Task<int> InsertSecondSemester(SecondSemester secondSemester) => await Insert(secondSemester);

    }
}
