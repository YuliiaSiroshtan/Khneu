using Planner.ServiceInterfaces.Interfaces.AppDiscipline;
using Planner.ServiceInterfaces.Interfaces.AppEntryLoad;
using Planner.ServiceInterfaces.Interfaces.AppSelectedDiscipline;
using Planner.ServiceInterfaces.Interfaces.AppUser;
using Planner.ServiceInterfaces.Interfaces.ServiceFactory;
using Planner.ServiceInterfaces.Interfaces.UniversityUnits;
using Planner.ServiceInterfaces.Interfaces.Сommon;

namespace Planner.BusinessLogic.Service.ServiceFactory
{
    public class ServiceFactory : IServiceFactory
    {
        public ServiceFactory(IUserService userService,
            ITokenService tokenService,
            ISecurityService securityService,
            IEntryLoadsPropertyService entryLoadsPropertyService,
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
            IPartTimeEntryLoadService partTimeEntryLoadService
        )
        {
            UserService = userService;
            TokenService = tokenService;
            SecurityService = securityService;
            EntryLoadsPropertyService = entryLoadsPropertyService;
            FullTimeEntryLoadService = fullTimeEntryLoadService;
            FirstSemester = firstSemesterService;
            SecondSemester = secondSemesterService;
            FacultyService = facultyService;
            DepartmentService = departmentService;
            FullTimeDisciplineService = fullTimeDisciplineService;
            SelectedDisciplineService = selectedDisciplineService;
            RateService = rateService;
            RoleService = roleService;
            ConstituentSessionService = constituentSessionService;
            ExaminationSessionService = examinationSessionService;
            PartTimeDisciplineService = partTimeDisciplineService;
            PartTimeEntryLoadService = partTimeEntryLoadService;
        }

        public IUserService UserService { get; }
        public ITokenService TokenService { get; }
        public ISecurityService SecurityService { get; }
        public IEntryLoadsPropertyService EntryLoadsPropertyService { get; }
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
    }
}