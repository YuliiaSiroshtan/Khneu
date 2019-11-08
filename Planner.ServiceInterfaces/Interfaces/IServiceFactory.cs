namespace Planner.ServiceInterfaces.Interfaces
{
    public interface IServiceFactory
    {
        IUserService UserService { get; }
        ITokenService TokenService { get; }
        ISecurityService SecurityService { get; }
        IEntryLoadsPropertyService EntryLoadsPropertyService { get; }
        IFullTimeEntryLoadService FullTimeEntryLoadService { get; }
        IFirstSemesterService FirstSemester { get; }
        ISecondSemesterService SecondSemester { get; }
        IFacultyService FacultyService { get; }
        IDepartmentService DepartmentService { get; }
        IDisciplineService DisciplineService { get; }
        ISelectedDisciplineService SelectedDisciplineService { get; }
        IRateService RateService { get; }
        IRoleService RoleService { get; }
        IConstituentSessionService ConstituentSessionService { get; }
        IExaminationSessionService ExaminationSessionService { get; }
        IPartTimeDisciplineService PartTimeDisciplineService { get; }
        IPartTimeEntryLoadService PartTimeEntryLoadService { get; }
    }
}
