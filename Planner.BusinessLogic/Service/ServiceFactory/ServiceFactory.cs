using Planner.ServiceInterfaces.Interfaces.AppDiscipline;
using Planner.ServiceInterfaces.Interfaces.AppEntryLoad;
using Planner.ServiceInterfaces.Interfaces.AppExcel;
using Planner.ServiceInterfaces.Interfaces.AppSelectedDiscipline;
using Planner.ServiceInterfaces.Interfaces.AppUser;
using Planner.ServiceInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces.ServiceFactory;
using Planner.ServiceInterfaces.Interfaces.UniversityUnits;

namespace Planner.BusinessLogic.Service.ServiceFactory
{
    public class ServiceFactory : IServiceFactory
    {
        public ServiceFactory(IUserService userService,
            ITokenService tokenService,
            ISecurityService securityService,
            IEntryLoadPropertyService entryLoadPropertyService,
            IFullTimeEntryLoadService fullTimeEntryLoadService,
            IFirstSemesterService firstSemesterService,
            ISecondSemesterService secondSemesterService,
            IFacultyService facultyService,
            IDepartmentService departmentService,
            IFullTimeDisciplineService fullTimeDisciplineService,
            ISelectedDisciplineService selectedDisciplineService,
            IRateService rateService,
            IRoleService roleService,
            IConstituentSessionService constituentSessionService,
            IExaminationSessionService examinationSessionService,
            IPartTimeDisciplineService partTimeDisciplineService,
            IPartTimeEntryLoadService partTimeEntryLoadService,
            IHoursCalculationOfFirstSemesterService hoursCalculationOfFirstSemesterService,
            IHoursCalculationOfSecondSemesterService hoursCalculationOfSecondSemesterService,
            IUserEntryLoadPropertyService userEntryLoadPropertyService,
            ILectureService lectureService,
            ILaboratoryService laboratoryService,
            IPracticalService practicalService,
            IExcelService excelService)
        {
            this.UserService = userService;
            this.TokenService = tokenService;
            this.SecurityService = securityService;
            this.EntryLoadPropertyService = entryLoadPropertyService;
            this.FullTimeEntryLoadService = fullTimeEntryLoadService;
            this.FirstSemester = firstSemesterService;
            this.SecondSemester = secondSemesterService;
            this.FacultyService = facultyService;
            this.DepartmentService = departmentService;
            this.FullTimeDisciplineService = fullTimeDisciplineService;
            this.SelectedDisciplineService = selectedDisciplineService;
            this.RateService = rateService;
            this.RoleService = roleService;
            this.ConstituentSessionService = constituentSessionService;
            this.ExaminationSessionService = examinationSessionService;
            this.PartTimeDisciplineService = partTimeDisciplineService;
            this.PartTimeEntryLoadService = partTimeEntryLoadService;
            this.HoursCalculationOfFirstSemesterService = hoursCalculationOfFirstSemesterService;
            this.HoursCalculationOfSecondSemesterService = hoursCalculationOfSecondSemesterService;
            this.UserEntryLoadPropertyService = userEntryLoadPropertyService;
            this.LectureService = lectureService;
            this.LaboratoryService = laboratoryService;
            this.PracticalService = practicalService;
            this.ExcelService = excelService;
        }

        public IUserService UserService { get; }
        public ITokenService TokenService { get; }
        public ISecurityService SecurityService { get; }
        public IEntryLoadPropertyService EntryLoadPropertyService { get; }
        public IFullTimeEntryLoadService FullTimeEntryLoadService { get; }
        public IFirstSemesterService FirstSemester { get; }
        public ISecondSemesterService SecondSemester { get; }
        public IFacultyService FacultyService { get; }
        public IDepartmentService DepartmentService { get; }
        public IFullTimeDisciplineService FullTimeDisciplineService { get; }
        public ISelectedDisciplineService SelectedDisciplineService { get; }
        public IRateService RateService { get; }
        public IRoleService RoleService { get; }
        public IConstituentSessionService ConstituentSessionService { get; }
        public IExaminationSessionService ExaminationSessionService { get; }
        public IPartTimeDisciplineService PartTimeDisciplineService { get; }
        public IPartTimeEntryLoadService PartTimeEntryLoadService { get; }
        public IHoursCalculationOfFirstSemesterService HoursCalculationOfFirstSemesterService { get; }
        public IHoursCalculationOfSecondSemesterService HoursCalculationOfSecondSemesterService { get; }
        public IUserEntryLoadPropertyService UserEntryLoadPropertyService { get; }
        public ILectureService LectureService { get; }
        public ILaboratoryService LaboratoryService { get; }
        public IPracticalService PracticalService { get; }
        public IExcelService ExcelService { get; }
    }
}