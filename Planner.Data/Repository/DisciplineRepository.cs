using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.RepositoryInterfaces.ObjectInterfaces;

namespace Planner.Data.Repository
{
    public class DisciplineRepository : GenericRepository<Discipline>, IDisciplineRepository
    {
        public DisciplineRepository(string connectionString, string tableName) : base(connectionString, tableName)
        {
        }

        public async Task<IEnumerable<Discipline>> GetDisciplines() => await GetEntities();
        public async Task<IEnumerable<Discipline>> GetDisciplinesByDepartmentId(int id)
        {
            using var connection = await OpenConnection();

            const string query = "SELECT * FROM Disciplines d " +
                                 "FULL JOIN FirstSemesters fs ON fs.Id = d.FirstSemesterId " +
                                 "FULL JOIN SecondSemesters ss ON ss.Id = d.SecondSemesterId " +
                                 "JOIN Departments dp ON dp.Id = d.DepartmentId JOIN Faculties f ON f.Id = dp.FacultyId " +
                                 "WHERE d.DepartmentId = @id AND(fs.Id IS NULL OR ss.Id IS NULL); ";

            return await connection
                .QueryAsync<Discipline, FirstSemester, SecondSemester, Department, Faculty, Discipline>
                (query, (discipline, firstSemester, secondSemester, department, faculty) =>
                {
                    discipline.FirstSemester = firstSemester;
                    discipline.SecondSemester = secondSemester;
                    department.Faculty = faculty;
                    discipline.Department = department;

                    return discipline;
                }, new { Id = id });

        }

        public async Task DeleteDiscipline(int id) => await DeleteEntity(id);

        public async Task<Discipline> GetDisciplineById(int id) => await GetEntityById(id);

        public async Task<Discipline> GetDisciplineByName(string name) => await GetEntityByName(name);

        public async Task UpdateDiscipline(Discipline discipline) => await Update(discipline);

        public async Task<int> InsertDiscipline(Discipline discipline) => await Insert(discipline);
    }
}
