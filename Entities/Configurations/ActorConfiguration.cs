using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configurations
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(prop => prop.Name)
            .HasMaxLength(70)
            .IsRequired();
        }
    }
}
