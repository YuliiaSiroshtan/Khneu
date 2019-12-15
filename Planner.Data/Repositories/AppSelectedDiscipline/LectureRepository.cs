using Planner.Data.Repositories.GenericRepository;
using Planner.Entities.Domain.AppSelectedDiscipline;
using Planner.RepositoryInterfaces.Interfaces.AppSelectedDiscipline;
using System.Threading.Tasks;

namespace Planner.Data.Repositories.AppSelectedDiscipline
{
    public class LectureRepository : GenericRepository<Lecture>, ILectureRepository
    {
        public LectureRepository(string connectionString, string tableName) : base(connectionString, tableName) { }

        public async Task<int> InsertLecture(Lecture lecture) => await this.Insert(lecture);
    }
}