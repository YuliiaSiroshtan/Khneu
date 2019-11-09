using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.RepositoryInterfaces.ObjectInterfaces;

namespace Planner.Data.Repository
{
    public class PartTimeDisciplineRepository: GenericRepository<PartTimeDiscipline>, IPartTimeDisciplineRepository
    {
        public PartTimeDisciplineRepository(string connectionString, string tableName) : base(connectionString, tableName)
        {
        }

        public async Task<IEnumerable<PartTimeDiscipline>> GetPartTimeDisciplines() => await GetEntities();
        public async Task<IEnumerable<PartTimeDiscipline>> GetPartTimeDisciplinesByDepartmentId(int id)
        {
            using var connection = await OpenConnection();

            const string query = "SELECT * FROM PartTimeDisciplines d " +
                                 "FULL JOIN ConstituentSessions cs ON cs.Id = d.ConstituentSessionId " +
                                 "FULL JOIN ExaminationSessions es ON es.Id = d.ExaminationSessionId " +
                                 "JOIN Departments dp ON dp.Id = d.DepartmentId JOIN Faculties f ON f.Id = dp.FacultyId " +
                                 "WHERE d.DepartmentId = @id AND(cs.Id IS NULL OR es.Id IS NULL); ";

            return await connection
                .QueryAsync<PartTimeDiscipline, ConstituentSession, ExaminationSession, Department, Faculty, PartTimeDiscipline>
                (query, (discipline, constituentSession, examinationSession, department, faculty) =>
                {
                    discipline.ConstituentSession = constituentSession;
                    discipline.ExaminationSession = examinationSession;
                    department.Faculty = faculty;
                    discipline.Department = department;

                    return discipline;
                }, new { Id = id });
        }

        public async Task DeletePartTimeDiscipline(int id) => await DeleteEntity(id);

        public async Task<PartTimeDiscipline> GetPartTimeDisciplineById(int id) => await GetEntityById(id);

        public async Task<PartTimeDiscipline> GetPartTimeDisciplineByName(string name) => await GetEntityByName(name);

        public async Task UpdatePartTimeDiscipline(PartTimeDiscipline partTimeDiscipline) =>
            await Update(partTimeDiscipline);

        public async Task<int> InsertPartTimeDiscipline(PartTimeDiscipline partTimeDiscipline) =>
            await Insert(partTimeDiscipline);
    }
}
