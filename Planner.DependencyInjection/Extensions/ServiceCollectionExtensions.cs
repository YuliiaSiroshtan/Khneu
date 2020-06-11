using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Planner.BusinessLogic.Services.AppDiscipline;
using Planner.BusinessLogic.Services.AppEntryLoad;
using Planner.BusinessLogic.Services.AppExcel;
using Planner.BusinessLogic.Services.AppIndividualPlan;
using Planner.BusinessLogic.Services.AppNdr;
using Planner.BusinessLogic.Services.AppPublication;
using Planner.BusinessLogic.Services.AppSelectedDiscipline;
using Planner.BusinessLogic.Services.AppUniversityUnits;
using Planner.BusinessLogic.Services.AppUser;
using Planner.BusinessLogic.Services.Misc;
using Planner.Data.Repositories.AppDiscipline;
using Planner.Data.Repositories.AppEntryLoad;
using Planner.Data.Repositories.AppSelectedDiscipline;
using Planner.Data.Repositories.AppUser;
using Planner.Data.Repositories.Misc;
using Planner.Data.Repositories.UniversityUnits;
using Planner.RepositoryInterfaces.Interfaces.AppDiscipline;
using Planner.RepositoryInterfaces.Interfaces.AppEntryLoad;
using Planner.RepositoryInterfaces.Interfaces.AppSelectedDiscipline;
using Planner.RepositoryInterfaces.Interfaces.AppUser;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.RepositoryInterfaces.Interfaces.UniversityUnits;
using Planner.ServiceInterfaces.Interfaces.AppDiscipline;
using Planner.ServiceInterfaces.Interfaces.AppEntryLoad;
using Planner.ServiceInterfaces.Interfaces.AppExcel;
using Planner.ServiceInterfaces.Interfaces.AppIndividualPlan;
using Planner.ServiceInterfaces.Interfaces.AppNdr;
using Planner.ServiceInterfaces.Interfaces.AppPublication;
using Planner.ServiceInterfaces.Interfaces.AppSelectedDiscipline;
using Planner.ServiceInterfaces.Interfaces.AppUser;
using Planner.ServiceInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces.UniversityUnits;
using System;
using IServiceScope = Planner.ServiceInterfaces.Interfaces.Misc.IServiceScope;

namespace Planner.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IRepositoryScope, RepositoryScope>(provider => new RepositoryScope(configuration
                .GetConnectionString("DefaultConnection")));
            services.AddSingleton<IRecreateTables, RecreateTables>(provider => new RecreateTables(configuration
                .GetConnectionString("DefaultConnection")));

            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IFullTimeEntryLoadRepository, FullTimeEntryLoadRepository>();
            services.AddSingleton<IEntryLoadPropertyRepository, EntryLoadPropertyRepository>();
            services.AddSingleton<IFirstSemesterRepository, FirstSemesterRepository>();
            services.AddSingleton<ISecondSemesterRepository, SecondSemesterRepository>();
            services.AddSingleton<IFacultyRepository, FacultyRepository>();
            services.AddSingleton<IDepartmentRepository, DepartmentRepository>();
            services.AddSingleton<IFullTimeDisciplineRepository, FullTimeDisciplineRepository>();
            services.AddSingleton<ISelectedDisciplineRepository, SelectedDisciplineRepository>();
            services.AddSingleton<IRateRepository, RateRepository>();
            services.AddSingleton<IRoleRepository, RoleRepository>();
            services.AddSingleton<IPartTimeDisciplineRepository, PartTimeDisciplineRepository>();
            services.AddSingleton<IConstituentSessionRepository, ConstituentSessionRepository>();
            services.AddSingleton<IExaminationSessionRepository, ExaminationSessionRepository>();
            services.AddSingleton<IPartTimeEntryLoadRepository, PartTimeEntryLoadRepository>();
            services
                .AddSingleton<IHoursCalculationOfFirstSemesterRepository, HoursCalculationOfFirstSemesterRepository>();
            services
                .AddSingleton<IHoursCalculationOfSecondSemesterRepository, HoursCalculationOfSecondSemesterRepository
                >();
            services.AddSingleton<IUserEntryLoadPropertyRepository, UserEntryLoadPropertyRepository>();
            services.AddSingleton<ILectureRepository, LectureRepository>();
            services.AddSingleton<ILaboratoryRepository, LaboratoryRepository>();
            services.AddSingleton<IPracticalRepository, PracticalRepository>();

            services.AddTransient<IServiceScope, ServiceScope>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient<IFullTimeEntryLoadService, FullTimeEntryLoadService>();
            services.AddTransient<IEntryLoadPropertyService, EntryLoadPropertyService>();
            services.AddTransient<IFirstSemesterService, FirstSemesterService>();
            services.AddTransient<ISecondSemesterService, SecondSemesterService>();
            services.AddTransient<IFacultyService, FacultyService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IFullTimeDisciplineService, FullTimeDisciplineService>();
            services.AddTransient<ISelectedDisciplineService, SelectedDisciplineService>();
            services.AddTransient<IRateService, RateService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IPartTimeDisciplineService, PartTimeDisciplineService>();
            services.AddTransient<IPartTimeEntryLoadService, PartTimeEntryLoadService>();
            services.AddTransient<IConstituentSessionService, ConstituentSessionService>();
            services.AddTransient<IExaminationSessionService, ExaminationSessionService>();
            services.AddTransient<IHoursCalculationOfFirstSemesterService, HoursCalculationOfFirstSemesterService>();
            services.AddTransient<IHoursCalculationOfSecondSemesterService, HoursCalculationOfSecondSemesterService>();
            services.AddTransient<IUserEntryLoadPropertyService, UserEntryLoadPropertyService>();
            services.AddTransient<ILectureService, LectureService>();
            services.AddTransient<ILaboratoryService, LaboratoryService>();
            services.AddTransient<IPracticalService, PracticalService>();
            services.AddSingleton<IExcelService, ExcelService>();
            services.AddSingleton<IPublicationService, PublicationService>();
            services.AddSingleton<INdrService, NdrService>();
            services.AddSingleton<IIndividualPlanService, IndividualPlanService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}