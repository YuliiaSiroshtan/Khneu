using Dapper;
using Planner.Data.Repositories.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.Domain.AppSelectedDiscipline;
using Planner.Entities.Domain.UniversityUnits;
using Planner.RepositoryInterfaces.Interfaces.AppEntryLoad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Data.Repositories.AppEntryLoad
{
    public class FullTimeEntryLoadRepository : GenericRepository<FullTimeEntryLoad>, IFullTimeEntryLoadRepository
    {
        public FullTimeEntryLoadRepository(string connectionString, string tableName) : base(connectionString,
            tableName) { }

        public async Task<IEnumerable<FullTimeEntryLoad>> GetFullTimeEntryLoads() => await this.GetEntities();

        public async Task<IEnumerable<FullTimeEntryLoad>> GetFullTimeEntryLoadsByUserId(int id)
        {
            using var connection = await this.OpenConnection();

            const string query = "SELECT * FROM FullTimeEntryLoads ld " +
                                 "JOIN FullTimeDisciplines d ON d.Id = ld.FullTimeDisciplineId " +
                                 "JOIN SelectedDisciplines sd ON sd.Name = d.Name " + "AND sd.ECTS = d.ECTS " +
                                 "AND sd.AmountOfHours = d.AmountOfHours " +
                                 "AND sd.DepartmentId = d.DepartmentId " +
                                 "AND sd.DepartmentId = d.DepartmentId " +
                                 "FULL JOIN FirstSemesters fs ON fs.Id = d.FirstSemesterId " +
                                 "FULL JOIN SecondSemesters ss ON ss.Id = d.SecondSemesterId " +
                                 "JOIN UserSelectedDiscipline usd ON usd.SelectedDisciplineId = sd.Id " +
                                 "JOIN Faculties f ON f.Id = ld.FacultyId " +
                                 "JOIN Departments dp ON dp.Id = d.DepartmentId " +
                                 "FULL JOIN HoursCalculationOfFirstSemesters hfs ON hfs.Id = ld.HoursCalculationOfFirstSemesterId " +
                                 "FULL JOIN HoursCalculationOfSecondSemesters hss ON hss.Id = ld.HoursCalculationOfSecondSemesterId " +
                                 "WHERE usd.UserId = @id " +
                                 "AND ld.Specialization = sd.Specialization " +
                                 "AND ld.Course = sd.Course;";

            return await connection.QueryAsync(query, new[]
            {
                typeof(FullTimeEntryLoad),
                typeof(FullTimeDiscipline),
                typeof(SelectedDiscipline),
                typeof(FirstSemester),
                typeof(SecondSemester),
                typeof(Faculty),
                typeof(Department),
                typeof(HoursCalculationOfFirstSemester),
                typeof(HoursCalculationOfSecondSemester)
            }, objects =>
            {
                if (!(objects[0] is FullTimeEntryLoad fullTimeEntryLoad)) return null;

                fullTimeEntryLoad.Faculty = objects[5] as Faculty;

                if (!(objects[1] is FullTimeDiscipline fullTimeDiscipline)) return fullTimeEntryLoad;

                fullTimeDiscipline.FirstSemester = objects[3] as FirstSemester;
                fullTimeDiscipline.SecondSemester = objects[4] as SecondSemester;
                fullTimeDiscipline.Department = objects[6] as Department;

                fullTimeEntryLoad.FullTimeDiscipline = fullTimeDiscipline;

                if (objects[7] is HoursCalculationOfFirstSemester hoursCalculationOfFirstSemester)
                    fullTimeEntryLoad.HoursCalculationOfFirstSemester = hoursCalculationOfFirstSemester;

                if (objects[8] is HoursCalculationOfSecondSemester hoursCalculationOfSecondSemester)
                    fullTimeEntryLoad.HoursCalculationOfSecondSemester = hoursCalculationOfSecondSemester;

                return fullTimeEntryLoad;
            }, new {Id = id});
        }

        public async Task<FullTimeEntryLoad> GetFullTimeEntryLoadById(int id) => await this.GetEntityById(id);

        public async Task<int> InsertFullTimeEntryLoad(FullTimeEntryLoad fullTimeEntryLoad) =>
            await this.Insert(fullTimeEntryLoad);
    }
}