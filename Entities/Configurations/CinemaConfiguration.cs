using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCoreMovies.Entities.Configurations
{
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.Property(prop => prop.Name)
                .HasMaxLength(70)
                .IsRequired();
        }
    }
}
