using Microsoft.EntityFrameworkCore;
using Planner.Data.Configuration;
using Planner.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> context) : base(context) { }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<DDataStorage> DDataStorage { get; set; }
        public DbSet<DayEntryLoad> DayEntryLoad { get; set; }
        public DbSet<DaySemester> DaySemester { get; set; }
        public DbSet<DayTeachLoad> DayTeachLoad { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<DepartmentUser> DepartmentUser { get; set; }
        public DbSet<EDataStorage> EDataStorage { get; set; }
        public DbSet<ExternalCollaborator> ExternalCollaborator { get; set; }
        public DbSet<ExtramuralEntryLoad> ExtramuralEntryLoad { get; set; }
        public DbSet<ExtramuralSemester> ExtramuralSemester { get; set; }
        public DbSet<ExtramuralTeachLoad> ExtramuralTeachLoad { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<IndPlanType> IndPlanType { get; set; }
        public DbSet<IndivPlanFields> IndivPlanFields { get; set; }
        public DbSet<IndivPlanFieldsValue> IndivPlanFieldsValue { get; set; }
        public DbSet<LoadingList> LoadingList { get; set; }
        public DbSet<NDR> NDR { get; set; }
        public DbSet<NMBD> NMBD { get; set; }
        public DbSet<PlanChange> PlanChange { get; set; }
        public DbSet<PlanConclusion> PlanConclusion { get; set; }
        public DbSet<PlanManagment> PlanManagment { get; set; }
        public DbSet<PlanMethodicalWork> PlanMethodicalWork { get; set; }
        public DbSet<PlanRemark> PlanRemark { get; set; }
        public DbSet<PlanTrainingJob> PlanTrainingJob { get; set; }
        public DbSet<Publication> Publication { get; set; }
        //public DbSet<PublicationNMBD> PublicationNMBD { get; set; }
        public DbSet<PublicationUser> PublicationUser { get; set; }
        public DbSet<Rate> Rate { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<ScientificPublishing> ScientificPublishing { get; set; }
        public DbSet<Specialize> Specialize { get; set; }
        public DbSet<Specialty> Specialty { get; set; }
        public DbSet<Subject> Subject { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            //modelBuilder.ApplyConfiguration(new PublicationNMBDConfiguration());
        }
    }
}
