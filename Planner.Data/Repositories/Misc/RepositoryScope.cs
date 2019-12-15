using Planner.Data.Repositories.AppDiscipline;
using Planner.Data.Repositories.AppEntryLoad;
using Planner.Data.Repositories.AppSelectedDiscipline;
using Planner.Data.Repositories.AppUser;
using Planner.Data.Repositories.UniversityUnits;
using Planner.Entities.ConstNames;
using Planner.RepositoryInterfaces.Interfaces.AppDiscipline;
using Planner.RepositoryInterfaces.Interfaces.AppEntryLoad;
using Planner.RepositoryInterfaces.Interfaces.AppSelectedDiscipline;
using Planner.RepositoryInterfaces.Interfaces.AppUser;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.RepositoryInterfaces.Interfaces.UniversityUnits;

namespace Planner.Data.Repositories.Misc
{
    public class RepositoryScope : IRepositoryScope
    {
        public RepositoryScope(string connectionString)
        {
            this.UserRepository = new UserRepository(connectionString, TableNames.User.Users);
            this.EntryLoadPropertyRepository =
                new EntryLoadPropertyRepository(connectionString, TableNames.EntryLoad.EntryLoadsProperties);
            this.FullTimeEntryLoadRepository =
                new FullTimeEntryLoadRepository(connectionString, TableNames.EntryLoad.FullTimeEntryLoads);
            this.FirstSemesterRepository =
                new FirstSemesterRepository(connectionString, TableNames.Semester.FirstSemesters);
            this.SecondSemesterRepository =
                new SecondSemesterRepository(connectionString, TableNames.Semester.SecondSemester);
            this.FacultyRepository = new FacultyRepository(connectionString, TableNames.UniversityUnit.Faculties);
            this.DepartmentRepository =
                new DepartmentRepository(connectionString, TableNames.UniversityUnit.Departments);
            this.FullTimeDisciplineRepository =
                new FullTimeDisciplineRepository(connectionString, TableNames.Disciplines.FullTimeDisciplines);
            this.SelectedDisciplineRepository =
                new SelectedDisciplineRepository(connectionString, TableNames.Disciplines.SelectedDisciplines);
            this.RateRepository = new RateRepository(connectionString, TableNames.User.Rates);
            this.RoleRepository = new RoleRepository(connectionString, TableNames.User.Roles);
            this.ConstituentSessionRepository =
                new ConstituentSessionRepository(connectionString, TableNames.Sessions.ConstituentSessions);
            this.ExaminationSessionRepository =
                new ExaminationSessionRepository(connectionString, TableNames.Sessions.ExaminationSessions);
            this.PartTimeDisciplineRepository =
                new PartTimeDisciplineRepository(connectionString, TableNames.Disciplines.PartTimeDisciplines);
            this.PartTimeEntryLoadRepository =
                new PartTimeEntryLoadRepository(connectionString, TableNames.EntryLoad.PartTimeEntryLoads);
            this.HoursCalculationOfFirstSemesterRepository =
                new HoursCalculationOfFirstSemesterRepository(connectionString,
                    TableNames.HoursCalculation.HoursCalculationOfFirstSemesters);
            this.HoursCalculationOfSecondSemesterRepository =
                new HoursCalculationOfSecondSemesterRepository(connectionString,
                    TableNames.HoursCalculation.HoursCalculationOfSecondSemesters);
            this.UserEntryLoadPropertyRepository =
                new UserEntryLoadPropertyRepository(connectionString, TableNames.EntryLoad.UserEntryLoadsProperties);
            this.LectureRepository = new LectureRepository(connectionString, TableNames.FormEducation.Lectures);
            this.LaboratoryRepository =
                new LaboratoryRepository(connectionString, TableNames.FormEducation.Laboratories);
            this.PracticalRepository = new PracticalRepository(connectionString, TableNames.FormEducation.Practicals);
        }

        public IUserRepository UserRepository { get; }
        public IEntryLoadPropertyRepository EntryLoadPropertyRepository { get; }
        public IFullTimeEntryLoadRepository FullTimeEntryLoadRepository { get; }
        public IFirstSemesterRepository FirstSemesterRepository { get; }
        public ISecondSemesterRepository SecondSemesterRepository { get; }
        public IFacultyRepository FacultyRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }
        public IFullTimeDisciplineRepository FullTimeDisciplineRepository { get; }
        public ISelectedDisciplineRepository SelectedDisciplineRepository { get; }
        public IRateRepository RateRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IConstituentSessionRepository ConstituentSessionRepository { get; }
        public IExaminationSessionRepository ExaminationSessionRepository { get; }
        public IPartTimeEntryLoadRepository PartTimeEntryLoadRepository { get; }
        public IPartTimeDisciplineRepository PartTimeDisciplineRepository { get; }
        public IHoursCalculationOfFirstSemesterRepository HoursCalculationOfFirstSemesterRepository { get; }
        public IHoursCalculationOfSecondSemesterRepository HoursCalculationOfSecondSemesterRepository { get; }
        public IUserEntryLoadPropertyRepository UserEntryLoadPropertyRepository { get; }
        public ILectureRepository LectureRepository { get; }
        public ILaboratoryRepository LaboratoryRepository { get; }
        public IPracticalRepository PracticalRepository { get; }
    }
}