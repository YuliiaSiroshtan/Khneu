using Planner.RepositoryInterfaces.ObjectInterfaces.AppDiscipline;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppEntryLoad;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppSelectedDiscipline;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppUser;
using Planner.RepositoryInterfaces.ObjectInterfaces.UniversityUnits;

namespace Planner.RepositoryInterfaces.UoW
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IEntryLoadsPropertyRepository EntryLoadsPropertyRepository { get; }
        IFullTimeEntryLoadRepository FullTimeEntryLoadRepository { get; }
        IFirstSemesterRepository FirstSemesterRepository { get; }
        ISecondSemesterRepository SecondSemesterRepository { get; }
        IFacultyRepository FacultyRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IFullTimeDisciplineRepository FullTimeDisciplineRepository { get; }
        ISelectedDisciplineRepository SelectedDisciplineRepository { get; }
        IRateRepository RateRepository { get; }
        IRoleRepository RoleRepository { get; }
        IConstituentSessionRepository ConstituentSessionRepository { get; }
        IExaminationSessionRepository ExaminationSessionRepository { get; }
        IPartTimeEntryLoadRepository PartTimeEntryLoadRepository { get; }
        IPartTimeDisciplineRepository PartTimeDisciplineRepository { get; }
        IHoursCalculationOfFirstSemesterRepository HoursCalculationOfFirstSemesterRepository { get; }
        IHoursCalculationOfSecondSemesterRepository HoursCalculationOfSecondSemesterRepository { get; }
    }
}
