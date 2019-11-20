using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Planner.BusinessLogic.Service.AppDiscipline;
using Planner.BusinessLogic.Service.AppEntryLoad;
using Planner.BusinessLogic.Service.AppSelectedDiscipline;
using Planner.BusinessLogic.Service.AppUser;
using Planner.BusinessLogic.Service.ServiceFactory;
using Planner.BusinessLogic.Service.UniversityUnits;
using Planner.BusinessLogic.Service.Сommon;
using Planner.Data.Repository.AppDiscipline;
using Planner.Data.Repository.AppEntryLoad;
using Planner.Data.Repository.AppSelectedDiscipline;
using Planner.Data.Repository.AppUser;
using Planner.Data.Repository.UniversityUnits;
using Planner.Data.UoW;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppDiscipline;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppEntryLoad;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppSelectedDiscipline;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppUser;
using Planner.RepositoryInterfaces.ObjectInterfaces.UniversityUnits;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppDiscipline;
using Planner.ServiceInterfaces.Interfaces.AppEntryLoad;
using Planner.ServiceInterfaces.Interfaces.AppSelectedDiscipline;
using Planner.ServiceInterfaces.Interfaces.AppUser;
using Planner.ServiceInterfaces.Interfaces.ServiceFactory;
using Planner.ServiceInterfaces.Interfaces.UniversityUnits;
using Planner.ServiceInterfaces.Interfaces.Сommon;
using System;

namespace Planner.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>(provider => new UnitOfWork(configuration
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
            services.AddSingleton<IHoursCalculationOfFirstSemesterRepository, HoursCalculationOfFirstSemesterRepository>();
            services.AddSingleton<IHoursCalculationOfSecondSemesterRepository, HoursCalculationOfSecondSemesterRepository>();
            services.AddSingleton<IUserEntryLoadPropertyRepository, UserEntryLoadPropertyRepository>();

            services.AddTransient<IServiceFactory, ServiceFactory>();
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

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
