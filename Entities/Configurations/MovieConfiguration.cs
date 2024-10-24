using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCoreMovies.Entities.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(prop => prop.Title)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(prop => prop.PosterURL)
                .HasMaxLength(500)
                .IsUnicode(false);
        }
    }
}
