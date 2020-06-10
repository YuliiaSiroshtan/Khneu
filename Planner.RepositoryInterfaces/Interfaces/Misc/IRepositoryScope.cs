using Planner.RepositoryInterfaces.Interfaces.AppDiscipline;
using Planner.RepositoryInterfaces.Interfaces.AppEntryLoad;
using Planner.RepositoryInterfaces.Interfaces.AppPublication;
using Planner.RepositoryInterfaces.Interfaces.AppSelectedDiscipline;
using Planner.RepositoryInterfaces.Interfaces.AppUser;
using Planner.RepositoryInterfaces.Interfaces.UniversityUnits;

namespace Planner.RepositoryInterfaces.Interfaces.Misc
{
    public interface IRepositoryScope
    {
        IUserRepository UserRepository { get; }
        IEntryLoadPropertyRepository EntryLoadPropertyRepository { get; }
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
        IUserEntryLoadPropertyRepository UserEntryLoadPropertyRepository { get; }
        ILectureRepository LectureRepository { get; }
        ILaboratoryRepository LaboratoryRepository { get; }
        IPracticalRepository PracticalRepository { get; }
        IPublicationRepository PublicationRepository { get; }
        INMBDRepository NMBDRepository { get; }
    }
}