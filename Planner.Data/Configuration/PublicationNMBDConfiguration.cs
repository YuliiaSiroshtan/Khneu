using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Entities.Domain;

namespace Planner.Data.Configuration
{
    public class PublicationNMBDConfiguration : IEntityTypeConfiguration<PublicationNMBD>
    {
        public void Configure(EntityTypeBuilder<PublicationNMBD> builder)
        {
            //builder.HasKey(s => new { s.PublicationId, s.NMBDId });

            //builder.HasOne(s => s.Publication)
            //       .WithMany(s => s.PublicationNMBDs)
            //       .HasForeignKey(s => s.PublicationId);

            //builder.HasOne(s => s.NMBD)
            //       .WithMany(s => s.PublicationNMBDs)
            //       .HasForeignKey(s => s.NMBDId);
        }
    }
}
