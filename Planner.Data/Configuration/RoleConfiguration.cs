using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Entities.Domain.AppUser;

namespace Planner.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role
            {
                Id = 1,
                Name = "Завідувач наукового секотору"
            }, new Role
            {
                Id = 2,
                Name = "Викладач"
            }, new Role
            {
                Id = 3,
                Name = "Голова навчальної частини"
            }, new Role
            {
                Id = 4,
                Name = "Завідувач кафедри"
            }, new Role
            {
                Id = 5,
                Name = "Адміністратор"
            });
        }
    }
}
