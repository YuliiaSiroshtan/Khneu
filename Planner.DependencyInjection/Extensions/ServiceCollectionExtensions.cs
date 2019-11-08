using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Planner.Data.Context;
using Planner.RepositoryInterfaces.UoW;
using Planner.RepositoryInterfaces.ObjectInterfaces;
using Planner.Data.UoW;
using Planner.Data.Repository;
using Planner.ServiceInterfaces.Interfaces;
using Planner.BusinessLogic.Service;
using System;

namespace Planner.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration
                .GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("Planner.Data")));

            services.AddTransient<IUnitOfWork, UnitOfWork>(provider => new UnitOfWork(configuration
                .GetConnectionString("DefaultConnection")));

            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IFullTimeEntryLoadRepository, FullTimeEntryLoadRepository>();
            services.AddSingleton<IEntryLoadsPropertyRepository, EntryLoadsPropertyRepository>();
            services.AddSingleton<IFirstSemesterRepository, FirstSemesterRepository>();
            services.AddSingleton<ISecondSemesterRepository, SecondSemesterRepository>();
            services.AddSingleton<IFacultyRepository, FacultyRepository>(); 
            services.AddSingleton<IDepartmentRepository, DepartmentRepository>();
            services.AddSingleton<IDisciplineRepository, DisciplineRepository>();
            services.AddSingleton<ISelectedDisciplineRepository, SelectedDisciplineRepository>();
            services.AddSingleton<IRateRepository, RateRepository>();
            services.AddSingleton<IRoleRepository, RoleRepository>();
            services.AddSingleton<IPartTimeDisciplineRepository, PartTimeDisciplineRepository>();
            services.AddSingleton<IConstituentSessionRepository, ConstituentSessionRepository>();
            services.AddSingleton<IExaminationSessionRepository, ExaminationSessionRepository>();
            services.AddSingleton<IPartTimeEntryLoadRepository, PartTimeEntryLoadRepository>();

            services.AddTransient<IServiceFactory, ServiceFactory>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient<IFullTimeEntryLoadService, FullTimeEntryLoadService>();
            services.AddTransient<IEntryLoadsPropertyService, EntryLoadsPropertyService>();
            services.AddTransient<IFirstSemesterService, FirstSemesterService>();
            services.AddTransient<ISecondSemesterService, SecondSemesterService>();
            services.AddTransient<IFacultyService, FacultyService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IDisciplineService, DisciplineService>();
            services.AddTransient<ISelectedDisciplineService, SelectedDisciplineService>();
            services.AddTransient<IRateService, RateService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IPartTimeDisciplineService, PartTimeDisciplineService>();
            services.AddTransient<IPartTimeEntryLoadService, PartTimeEntryLoadService>();
            services.AddTransient<IConstituentSessionService, ConstituentSessionService>();
            services.AddTransient<IExaminationSessionService, ExaminationSessionService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
