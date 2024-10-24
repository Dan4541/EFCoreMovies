using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCoreMovies.Entities.Configurations
{
    public class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            builder.HasKey(prop => new { prop.MovieId, prop.ActorId });

            builder.Property(prop => prop.Character)
                .HasMaxLength(150);
        }
    }
}
