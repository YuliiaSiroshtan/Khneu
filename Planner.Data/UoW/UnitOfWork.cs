using Planner.Data.Repository;
using Planner.RepositoryInterfaces.ObjectInterfaces;
using Planner.RepositoryInterfaces.UoW;

namespace Planner.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(string connectionString)
        {
            UserRepository = new UserRepository(connectionString, "Users");
            EntryLoadsPropertyRepository = new EntryLoadsPropertyRepository(connectionString, "EntryLoadsProperties");
            FullTimeEntryLoadRepository = new FullTimeEntryLoadRepository(connectionString, "FullTimeEntryLoads");
            FirstSemesterRepository = new FirstSemesterRepository(connectionString, "FirstSemesters");
            SecondSemesterRepository = new SecondSemesterRepository(connectionString, "SecondSemesters");
            FacultyRepository = new FacultyRepository(connectionString, "Faculties");
            DepartmentRepository = new DepartmentRepository(connectionString, "Departments");
            DisciplineRepository = new DisciplineRepository(connectionString, "Disciplines");
            SelectedDisciplineRepository = new SelectedDisciplineRepository(connectionString, "SelectedDisciplines");
            RateRepository = new RateRepository(connectionString, "Rates");
            RoleRepository = new RoleRepository(connectionString, "Roles");
            ConstituentSessionRepository = new ConstituentSessionRepository(connectionString, "ConstituentSessions");
            ExaminationSessionRepository = new ExaminationSessionRepository(connectionString, "ExaminationSessions");
            PartTimeDisciplineRepository = new PartTimeDisciplineRepository(connectionString, "PartTimeDisciplines");
            PartTimeEntryLoadRepository = new PartTimeEntryLoadRepository(connectionString, "PartTimeEntryLoads");
        }

        public IUserRepository UserRepository { get; }
        public IEntryLoadsPropertyRepository EntryLoadsPropertyRepository { get; }
        public IFullTimeEntryLoadRepository FullTimeEntryLoadRepository { get; }
        public IFirstSemesterRepository FirstSemesterRepository { get; }
        public ISecondSemesterRepository SecondSemesterRepository { get; }
        public IFacultyRepository FacultyRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }
        public IDisciplineRepository DisciplineRepository { get; }
        public ISelectedDisciplineRepository SelectedDisciplineRepository { get; }
        public IRateRepository RateRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IConstituentSessionRepository ConstituentSessionRepository { get; }
        public IExaminationSessionRepository ExaminationSessionRepository { get; }
        public IPartTimeEntryLoadRepository PartTimeEntryLoadRepository { get; }
        public IPartTimeDisciplineRepository PartTimeDisciplineRepository { get; }
    }
}
