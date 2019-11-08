using Planner.ServiceInterfaces.Interfaces;

namespace Planner.BusinessLogic.Service
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
            IDisciplineService disciplineService, 
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
            DisciplineService = disciplineService;
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
        public IDisciplineService DisciplineService { get; }
        public ISelectedDisciplineService SelectedDisciplineService { get; }
        public IRateService RateService { get; }
        public IRoleService RoleService { get; }
        public IConstituentSessionService ConstituentSessionService { get; }
        public IExaminationSessionService ExaminationSessionService { get; }
        public IPartTimeDisciplineService PartTimeDisciplineService { get; }
        public IPartTimeEntryLoadService PartTimeEntryLoadService { get; }
    }
}