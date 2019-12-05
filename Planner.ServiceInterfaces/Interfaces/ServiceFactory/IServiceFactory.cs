using Planner.ServiceInterfaces.Interfaces.AppDiscipline;
using Planner.ServiceInterfaces.Interfaces.AppEntryLoad;
using Planner.ServiceInterfaces.Interfaces.AppExcel;
using Planner.ServiceInterfaces.Interfaces.AppSelectedDiscipline;
using Planner.ServiceInterfaces.Interfaces.AppUser;
using Planner.ServiceInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces.UniversityUnits;

namespace Planner.ServiceInterfaces.Interfaces.ServiceFactory
{
    public interface IServiceFactory
    {
        IUserService UserService { get; }
        ITokenService TokenService { get; }
        ISecurityService SecurityService { get; }
        IEntryLoadPropertyService EntryLoadPropertyService { get; }
        IFullTimeEntryLoadService FullTimeEntryLoadService { get; }
        IFirstSemesterService FirstSemester { get; }
        ISecondSemesterService SecondSemester { get; }
        IFacultyService FacultyService { get; }
        IDepartmentService DepartmentService { get; }
        IFullTimeDisciplineService FullTimeDisciplineService { get; }
        ISelectedDisciplineService SelectedDisciplineService { get; }
        IRateService RateService { get; }
        IRoleService RoleService { get; }
        IConstituentSessionService ConstituentSessionService { get; }
        IExaminationSessionService ExaminationSessionService { get; }
        IPartTimeDisciplineService PartTimeDisciplineService { get; }
        IPartTimeEntryLoadService PartTimeEntryLoadService { get; }
        IHoursCalculationOfFirstSemesterService HoursCalculationOfFirstSemesterService { get; }
        IHoursCalculationOfSecondSemesterService HoursCalculationOfSecondSemesterService { get; }
        IUserEntryLoadPropertyService UserEntryLoadPropertyService { get; }
        ILectureService LectureService { get; }
        ILaboratoryService LaboratoryService { get; }
        IPracticalService PracticalService { get; }
        IExcelService ExcelService { get; }
    }
}