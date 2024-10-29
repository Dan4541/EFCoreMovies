using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.InteropServices;

namespace EFCoreMovies.Entities.Configurations
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(prop => prop.Name)
            .HasMaxLength(70)
            .IsRequired();

            //Mapeo flexible
            builder.Property(prop => prop.Name).HasField("_Name");

            //Ignorar propiedades y clases
            //builder.Ignore(prop => prop.Age);
            
            //builder.Ignore(clxss => clxss.Direccion);
            //En este caso al ignorar la entidad dirección ef no la guarda en la bd
        }
    }
}
