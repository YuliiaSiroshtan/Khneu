using Planner.RepositoryInterfaces.ObjectInterfaces;

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
        IDisciplineRepository DisciplineRepository { get; }
        ISelectedDisciplineRepository SelectedDisciplineRepository { get; }
        IRateRepository RateRepository { get; }
        IRoleRepository RoleRepository { get; }
        IConstituentSessionRepository ConstituentSessionRepository { get; }
        IExaminationSessionRepository ExaminationSessionRepository { get; }
        IPartTimeEntryLoadRepository PartTimeEntryLoadRepository { get; }
        IPartTimeDisciplineRepository PartTimeDisciplineRepository { get; }
    }
}
