using EFCoreMovies.Entities;
using EFCoreMovies.Entities.Keyless;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace EFCoreMovies
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) :base(options)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //SeedingQueryModule.Seed(modelBuilder);

            modelBuilder.Entity<CinemaWithNoUbication>()
                .HasNoKey()
                .ToSqlQuery("Select Id, Name FROM Cines").ToView(null);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var propiedad in entityType.GetProperties())
                {
                    if (propiedad.ClrType == typeof(string) && propiedad.Name.Contains("URL", StringComparison.CurrentCultureIgnoreCase))
                    {
                        propiedad.SetIsUnicode(false);
                    }
                }

            }
        }

        
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cinema> Cines { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<CinemaOffer> CinemaOffers { get; set; }
        public DbSet<MovieTheater> MovieTheaters { get; set; }
        public DbSet<MovieActor> MoviesActors { get; set; }       
        public DbSet<Log> Logs { get; set; }
        public DbSet<CinemaWithNoUbication> cinemaWithNoUbications { get; set; }
        
    }
}
