using Microsoft.EntityFrameworkCore;
using Planner.Data.Configuration;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.Entities.Domain.AppUser;

namespace Planner.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> context) : base(context) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Rate> Rates { get; set; }

        public DbSet<IndividualPlan> IndividualPlans { get; set; }

        public DbSet<FullTimeEntryLoad> FullTimeEntryLoads { get; set; }

        public DbSet<PartTimeEntryLoad> PartTimeEntryLoads { get; set; }

        public DbSet<EntryLoadsProperty> EntryLoadsProperties { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Discipline> Disciplines { get; set; }

        public DbSet<PartTimeDiscipline> PartTimeDisciplines { get; set; }

        public DbSet<SelectedDiscipline> SelectedDisciplines { get; set; }

        public DbSet<FirstSemester> FirstSemesters { get; set; }

        public DbSet<SecondSemester> SecondSemesters { get; set; }

        public DbSet<ConstituentSession> ConstituentSessions { get; set; }

        public DbSet<ExaminationSession> ExaminationSessions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new FacultyConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());

            modelBuilder.Entity<User>().Ignore(c => c.Departments);
            modelBuilder.Entity<User>().Ignore(c => c.IndividualPlans);

            modelBuilder.Entity<Role>().Ignore(c => c.Users);

            modelBuilder.Entity<Faculty>().Ignore(c => c.Departments);

            modelBuilder.Entity<Department>().Ignore(c => c.Disciplines);
            modelBuilder.Entity<Department>().Ignore(c => c.DisciplinesInGraduateSchool);
        }
    }
}
