using Dapper;
using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.Entities.Domain.UniversityUnits;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppDiscipline;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Data.Repository.AppDiscipline
{
    public class PartTimeDisciplineRepository : GenericRepository<PartTimeDiscipline>, IPartTimeDisciplineRepository
    {
        public PartTimeDisciplineRepository(string connectionString, string tableName) : base(connectionString,
            tableName) { }

        public async Task<IEnumerable<PartTimeDiscipline>> GetPartTimeDisciplinesByDepartmentId(int id)
        {
            using var connection = await this.OpenConnection();

            const string query = "SELECT * FROM PartTimeDisciplines d " +
                                 "FULL JOIN ConstituentSessions cs ON cs.Id = d.ConstituentSessionId " +
                                 "FULL JOIN ExaminationSessions es ON es.Id = d.ExaminationSessionId " +
                                 "JOIN Departments dp ON dp.Id = d.DepartmentId " +
                                 "JOIN Faculties f ON f.Id = dp.FacultyId " +
                                 "WHERE d.DepartmentId = @id";

            return await connection
                .QueryAsync<PartTimeDiscipline, ConstituentSession, ExaminationSession, Department, Faculty,
                    PartTimeDiscipline>
                (query, (discipline, constituentSession, examinationSession, department, faculty) =>
                {
                    discipline.ConstituentSession = constituentSession;
                    discipline.ExaminationSession = examinationSession;
                    department.Faculty = faculty;
                    discipline.Department = department;

                    return discipline;
                }, new {Id = id});
        }

        public async Task<int> InsertPartTimeDiscipline(PartTimeDiscipline partTimeDiscipline) =>
            await this.Insert(partTimeDiscipline);
    }
}