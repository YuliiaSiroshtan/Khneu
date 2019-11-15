using Dapper;
using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.Domain.UniversityUnits;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppDiscipline;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Data.Repository.AppDiscipline
{
    public class FullTimeDisciplineRepository : GenericRepository<FullTimeDiscipline>, IFullTimeDisciplineRepository
    {
        public FullTimeDisciplineRepository(string connectionString, string tableName) : base(connectionString, tableName)
        {
        }

        public async Task<IEnumerable<FullTimeDiscipline>> GetFullTimeDisciplines() => await GetEntities();

        public async Task<IEnumerable<FullTimeDiscipline>> GetFullTimeDisciplinesByDepartmentId(int id)
        {
            using var connection = await OpenConnection();

            const string query = "SELECT * FROM FullTimeDisciplines d " +
                                 "FULL JOIN FirstSemesters fs ON fs.Id = d.FirstSemesterId " +
                                 "FULL JOIN SecondSemesters ss ON ss.Id = d.SecondSemesterId " +
                                 "JOIN Departments dp ON dp.Id = d.DepartmentId JOIN Faculties f ON f.Id = dp.FacultyId " +
                                 "WHERE d.DepartmentId = @id AND(fs.Id IS NULL OR ss.Id IS NULL); ";

            return await connection
                .QueryAsync<FullTimeDiscipline, FirstSemester, SecondSemester, Department, Faculty, FullTimeDiscipline>
                (query, (discipline, firstSemester, secondSemester, department, faculty) =>
                {
                    discipline.FirstSemester = firstSemester;
                    discipline.SecondSemester = secondSemester;
                    department.Faculty = faculty;
                    discipline.Department = department;

                    return discipline;
                }, new { Id = id });

        }

        public async Task DeleteFullTimeDiscipline(int id) => await DeleteEntity(id);

        public async Task<FullTimeDiscipline> GetFullTimeDisciplineById(int id) => await GetEntityById(id);

        public async Task<FullTimeDiscipline> GetFullTimeDisciplineByName(string name) => await GetEntityByName(name);

        public async Task UpdateFullTimeDiscipline(FullTimeDiscipline fullTimeDiscipline) => await Update(fullTimeDiscipline);

        public async Task<int> InsertFullTimeDiscipline(FullTimeDiscipline fullTimeDiscipline) => await Insert(fullTimeDiscipline);
    }
}
