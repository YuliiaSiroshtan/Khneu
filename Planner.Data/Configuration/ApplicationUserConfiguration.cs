using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Data.Configuration
{
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser> 
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(s => s.ApplicationUserId);

            builder.HasOne(s => s.Role)
                   .WithMany(s => s.Users)
                   .HasForeignKey(s => s.RoleId);
        }
    }
}
