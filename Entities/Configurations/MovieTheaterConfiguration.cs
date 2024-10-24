using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCoreMovies.Entities.Configurations
{
    public class MovieTheaterConfiguration : IEntityTypeConfiguration<MovieTheater>
    {
        public void Configure(EntityTypeBuilder<MovieTheater> builder)
        {
            builder.Property(prop => prop.Price)
                .HasPrecision(precision: 9, scale: 2);

            builder.Property(prop => prop.TheaterType)
                .HasDefaultValue(MovieTheaterType.TwoDimensions);
        }
    }
}
