using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCoreMovies.Entities.Configurations
{
    public class CinemaOfferConfiguration : IEntityTypeConfiguration<CinemaOffer>
    {
        public void Configure(EntityTypeBuilder<CinemaOffer> builder)
        {
            builder.Property(prop => prop.discountPersentage)
                .HasPrecision(precision: 5, scale: 2);
        }
    }
}
