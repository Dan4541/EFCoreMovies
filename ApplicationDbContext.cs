using EFCoreMovies.Entities;
using EFCoreMovies.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
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

            //Restricciones a traves de API FLUENT
            //modelBuilder.Entity<Genre>().Property(prop => prop.Name)
            //  .HasMaxLength(10)
            //.IsRequired();

            //modelBuilder.ApplyConfiguration(new GenreConfiguration());

            //modelBuilder.Entity<Actor>().Property(prop => prop.Name)
            //  .HasMaxLength(70)
            //.IsRequired();

            //modelBuilder.ApplyConfiguration(new ActorConfiguration());

            //modelBuilder.Entity<Actor>().Property(prop => prop.DateOfBirth)
            //  .HasColumnType("date");

            //modelBuilder.Entity<Cinema>().Property(prop => prop.Name)
            //  .HasMaxLength(70)
            //.IsRequired();

            //modelBuilder.ApplyConfiguration(new CinemaConfiguration());

            //modelBuilder.Entity<Movie>().Property(prop => prop.Title)
            //  .HasMaxLength(250)
            //.IsRequired();

            //modelBuilder.Entity<Movie>().Property(prop => prop.ReleaseDate)
            //  .HasColumnType("date");

            //modelBuilder.Entity<Movie>().Property(prop => prop.PosterURL)
            //  .HasMaxLength(500)
            //.IsUnicode(false);

            //modelBuilder.ApplyConfiguration(new MovieConfiguration());

            //modelBuilder.Entity<CinemaOffer>().Property(prop => prop.discountPersentage)
            //  .HasPrecision(precision: 5, scale: 2);

            //modelBuilder.Entity<CinemaOffer>().Property(prop => prop.startDate)
            //  .HasColumnType("date");

            //modelBuilder.Entity<CinemaOffer>().Property(prop => prop.endDate)
            //  .HasColumnType("date");

            //modelBuilder.ApplyConfiguration(new CinemaOfferConfiguration());

            //modelBuilder.Entity<MovieTheater>().Property(prop => prop.Price)
            //  .HasPrecision(precision: 9, scale: 2);

            //modelBuilder.Entity<MovieTheater>().Property(prop => prop.TheaterType)
            //  .HasDefaultValue(MovieTheaterType.TwoDimensions);

            //modelBuilder.ApplyConfiguration(new MovieTheaterConfiguration());

            //modelBuilder.Entity<MovieActor>().HasKey(prop => new { prop.MovieId, prop.ActorId });

            //modelBuilder.Entity<MovieActor>().Property(prop => prop.Character)
            //  .HasMaxLength(150);

            //modelBuilder.ApplyConfiguration(new MovieActorConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cinema> Cines { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<CinemaOffer> CinemaOffers { get; set; }
        public DbSet<MovieTheater> MovieTheaters { get; set; }
        public DbSet<MovieActor> MoviesActors { get; set; }

    }
}
