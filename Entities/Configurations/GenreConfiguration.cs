using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(prop => prop.Name)
               .HasMaxLength(50)
               .IsRequired();

            builder.HasQueryFilter(g => !g.IsDeleted);
        }
    }
}
