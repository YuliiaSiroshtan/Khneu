using Planner.ServiceInterfaces.Interfaces.AppDiscipline;
using Planner.ServiceInterfaces.Interfaces.AppEntryLoad;
using Planner.ServiceInterfaces.Interfaces.AppExcel;
using Planner.ServiceInterfaces.Interfaces.AppIndividualPlan;
using Planner.ServiceInterfaces.Interfaces.AppNdr;
using Planner.ServiceInterfaces.Interfaces.AppPublication;
using Planner.ServiceInterfaces.Interfaces.AppSelectedDiscipline;
using Planner.ServiceInterfaces.Interfaces.AppUser;
using Planner.ServiceInterfaces.Interfaces.UniversityUnits;

namespace Planner.ServiceInterfaces.Interfaces.Misc
{
    public interface IServiceScope
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
        IPublicationService PublicationService { get; }
        INdrService NdrService { get; }
        IIndividualPlanService IndividualPlanService { get; }
    }
}