using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Entities.Domain;

namespace Planner.Data.Configuration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(s => s.RoleId);
            builder.Property(s => s.Name)
                   .HasColumnName("Name")
                   .HasMaxLength(50);

        }
    }
}
