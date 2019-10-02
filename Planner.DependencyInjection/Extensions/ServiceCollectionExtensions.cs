using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Text;
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
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<INdrRepository, NdrRepository>();
            services.AddSingleton<IDayEntryLoadRepository, DayEntryLoadRepository>();
            services.AddSingleton<INMBDRepository, NMBDRepository>();
            services.AddSingleton<IRoleRepository, RoleRepository>();
            services.AddSingleton<IIndividualPlanFieldsRepository, IndividualPlanFieldRepository>();
            services.AddSingleton<IIndividualPlanFieldsValueRepository, IndividualPlanFieldsValueRepository>();
            
            services.AddSingleton<IPublicationRepository, PublicationRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IServiceFactory, ServiceFactory>();
            services.AddTransient<IDistributionService, DistributionService>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient<INdrService, NdrService>();
            services.AddTransient<IPublicationService, PublicationService>();
            services.AddTransient<IIndividualPlanService, IndividualPlanService>();


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
