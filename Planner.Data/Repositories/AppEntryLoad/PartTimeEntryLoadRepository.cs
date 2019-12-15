using Dapper;
using Planner.Data.Repositories.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.Entities.Domain.AppSelectedDiscipline;
using Planner.Entities.Domain.UniversityUnits;
using Planner.RepositoryInterfaces.Interfaces.AppEntryLoad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Data.Repositories.AppEntryLoad
{
    public class PartTimeEntryLoadRepository : GenericRepository<PartTimeEntryLoad>, IPartTimeEntryLoadRepository
    {
        public PartTimeEntryLoadRepository(string connectionString, string tableName) : base(connectionString,
            tableName) { }

        public async Task<IEnumerable<PartTimeEntryLoad>> GetPartTimeEntryLoads() => await this.GetEntities();

        public async Task<IEnumerable<PartTimeEntryLoad>> GetPartTimeEntryLoadsByUserId(int id)
        {
            using var connection = await this.OpenConnection();

            const string query = "SELECT * FROM PartTimeEntryLoads ld " +
                                 "JOIN PartTimeDisciplines d ON d.Id = ld.PartTimeDisciplineId " +
                                 "JOIN SelectedDisciplines sd ON sd.Name = d.Name " +
                                 "AND sd.ECTS = d.ECTS " +
                                 "AND sd.AmountOfHours = d.AmountOfHours " +
                                 "AND sd.DepartmentId = d.DepartmentId " +
                                 "FULL JOIN ConstituentSessions cs ON cs.Id = d.ConstituentSessionId " +
                                 "FULL JOIN ExaminationSessions es ON es.Id = d.ExaminationSessionId " +
                                 "JOIN UserSelectedDiscipline usd ON usd.SelectedDisciplineId = sd.Id " +
                                 "JOIN Departments dp ON dp.Id = d.DepartmentId " +
                                 "FULL JOIN HoursCalculationOfFirstSemesters hfs ON hfs.Id = ld.HoursCalculationOfFirstSemesterId " +
                                 "FULL JOIN HoursCalculationOfSecondSemesters hss ON hss.Id = ld.HoursCalculationOfSecondSemesterId " +
                                 "WHERE usd.UserId = @id " +
                                 "AND ld.Specialty = sd.Specialization " +
                                 "AND ld.Course = sd.Course; ";

            return await connection.QueryAsync(query, new[]
            {
                typeof(PartTimeEntryLoad),
                typeof(PartTimeDiscipline),
                typeof(SelectedDiscipline),
                typeof(ConstituentSession),
                typeof(ExaminationSession),
                typeof(Department),
                typeof(HoursCalculationOfFirstSemester),
                typeof(HoursCalculationOfSecondSemester)
            }, objects =>
            {
                if (!(objects[0] is PartTimeEntryLoad partTimeEntryLoad)) return null;

                if (!(objects[1] is PartTimeDiscipline partTimeDiscipline)) return partTimeEntryLoad;

                partTimeDiscipline.Department = objects[5] as Department;
                partTimeDiscipline.ConstituentSession = objects[3] as ConstituentSession;
                partTimeDiscipline.ExaminationSession = objects[4] as ExaminationSession;

                partTimeEntryLoad.PartTimeDiscipline = partTimeDiscipline;

                if (objects[6] is HoursCalculationOfFirstSemester hoursCalculationOfFirstSemester)
                    partTimeEntryLoad.HoursCalculationOfFirstSemester = hoursCalculationOfFirstSemester;

                if (objects[7] is HoursCalculationOfSecondSemester hoursCalculationOfSecondSemester)
                    partTimeEntryLoad.HoursCalculationOfSecondSemester = hoursCalculationOfSecondSemester;

                return partTimeEntryLoad;
            }, new {Id = id});
        }

        public async Task<PartTimeEntryLoad> GetPartTimeEntryLoadById(int id) => await this.GetEntityById(id);

        public async Task<int> InsertPartTimeEntryLoad(PartTimeEntryLoad partTimeEntryLoad) =>
            await this.Insert(partTimeEntryLoad);
    }
}