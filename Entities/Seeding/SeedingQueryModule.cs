using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using NetTopologySuite;
using System.Reflection.Emit;

namespace EFCoreMovies.Entities.Seeding
{
    public static class SeedingQueryModule
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var acción = new Genre { Id = 1, Name = "Acción" };
            var animación = new Genre { Id = 2, Name = "Animación" };
            var comedia = new Genre { Id = 3, Name = "Comedia" };
            var cienciaFicción = new Genre { Id = 4, Name = "Ciencia ficción" };
            var drama = new Genre { Id = 5, Name = "Drama" };

            modelBuilder.Entity<Genre>().HasData(acción, animación, comedia, cienciaFicción, drama);

            var tomHolland = new Actor() { Id = 1, Name = "Tom Holland", DateOfBirth = new DateTime(1996, 6, 1), Biography = "Thomas Stanley Holland (Kingston upon Thames, Londres; 1 de junio de 1996), conocido simplemente como Tom Holland, es un actor, actor de voz y bailarín británico." };
            var samuelJackson = new Actor() { Id = 2, Name = "Samuel L. Jackson", DateOfBirth = new DateTime(1948, 12, 21), Biography = "Samuel Leroy Jackson (Washington D. C., 21 de diciembre de 1948), conocido como Samuel L. Jackson, es un actor y productor de cine, televisión y teatro estadounidense. Ha sido candidato al premio Óscar, a los Globos de Oro y al Premio del Sindicato de Actores, así como ganador de un BAFTA al mejor actor de reparto." };
            var robertDowney = new Actor() { Id = 3, Name = "Robert Downey Jr.", DateOfBirth = new DateTime(1965, 4, 4), Biography = "Robert John Downey Jr. (Nueva York, 4 de abril de 1965) es un actor, actor de voz, productor y cantante estadounidense. Inició su carrera como actor a temprana edad apareciendo en varios filmes dirigidos por su padre, Robert Downey Sr., y en su infancia estudió actuación en varias academias de Nueva York." };
            var chrisEvans = new Actor() { Id = 4, Name = "Chris Evans", DateOfBirth = new DateTime(1981, 06, 13) };
            var laRoca = new Actor() { Id = 5, Name = "Dwayne Johnson", DateOfBirth = new DateTime(1972, 5, 2) };
            var auliCravalho = new Actor() { Id = 6, Name = "Auli'i Cravalho", DateOfBirth = new DateTime(2000, 11, 22) };
            var scarlettJohansson = new Actor() { Id = 7, Name = "Scarlett Johansson", DateOfBirth = new DateTime(1984, 11, 22) };
            var keanuReeves = new Actor() { Id = 8, Name = "Keanu Reeves", DateOfBirth = new DateTime(1964, 9, 2) };

            modelBuilder.Entity<Actor>().HasData(tomHolland, samuelJackson,
                            robertDowney, chrisEvans, laRoca, auliCravalho, scarlettJohansson, keanuReeves);
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var agora = new Cinema() { Id = 1, Name = "Agora Mall", Ubication = geometryFactory.CreatePoint(new Coordinate(-69.9388777, 18.4839233)) };
            var sambil = new Cinema() { Id = 2, Name = "Sambil", Ubication = geometryFactory.CreatePoint(new Coordinate(-69.911582, 18.482455)) };
            var megacentro = new Cinema() { Id = 3, Name = "Megacentro", Ubication = geometryFactory.CreatePoint(new Coordinate(-69.856309, 18.506662)) };
            var acropolis = new Cinema() { Id = 4, Name = "Acropolis", Ubication = geometryFactory.CreatePoint(new Coordinate(-69.939248, 18.469649)) };

            var agoraCineOferta = new CinemaOffer { Id = 1, CinemaId = agora.Id, startDate = DateTime.Today, endDate = DateTime.Today.AddDays(7), discountPersentage = 10 };

            var salaDeCine2DAgora = new MovieTheater()
            {
                Id = 1,
                CinemaId = agora.Id,
                Price = 220,
                TheaterType = MovieTheaterType.TwoDimensions
            };
            var salaDeCine3DAgora = new MovieTheater()
            {
                Id = 2,
                CinemaId = agora.Id,
                Price = 320,
                TheaterType = MovieTheaterType.ThreeDimensions
            };

            var salaDeCine2DSambil = new MovieTheater()
            {
                Id = 3,
                CinemaId = sambil.Id,
                Price = 200,
                TheaterType = MovieTheaterType.TwoDimensions
            };
            var salaDeCine3DSambil = new MovieTheater()
            {
                Id = 4,
                CinemaId = sambil.Id,
                Price = 290,
                TheaterType = MovieTheaterType.ThreeDimensions
            };


            var salaDeCine2DMegacentro = new MovieTheater()
            {
                Id = 5,
                CinemaId = megacentro.Id,
                Price = 250,
                TheaterType = MovieTheaterType.TwoDimensions
            };
            var salaDeCine3DMegacentro = new MovieTheater()
            {
                Id = 6,
                CinemaId = megacentro.Id,
                Price = 330,
                TheaterType = MovieTheaterType.ThreeDimensions
            };
            var salaDeCineCXCMegacentro = new MovieTheater()
            {
                Id = 7,
                CinemaId = megacentro.Id,
                Price = 450,
                TheaterType = MovieTheaterType.CxC
            };

            var salaDeCine2DAcropolis = new MovieTheater()
            {
                Id = 8,
                CinemaId = acropolis.Id,
                Price = 250,
                TheaterType = MovieTheaterType.TwoDimensions
            };

            var acropolisCineOferta = new CinemaOffer { Id = 2, CinemaId = acropolis.Id, startDate = DateTime.Today, endDate = DateTime.Today.AddDays(5), discountPersentage = 15 };

            modelBuilder.Entity<Cinema>().HasData(acropolis, sambil, megacentro, agora);
            modelBuilder.Entity<CinemaOffer>().HasData(acropolisCineOferta, agoraCineOferta);
            modelBuilder.Entity<MovieTheater>().HasData(salaDeCine2DMegacentro, salaDeCine3DMegacentro, salaDeCineCXCMegacentro, salaDeCine2DAcropolis, salaDeCine2DAgora, salaDeCine3DAgora, salaDeCine2DSambil, salaDeCine3DSambil);


            var avengers = new Movie()
            {
                Id = 1,
                Title = "Avengers",
                OnBillboard = false,
                ReleaseDate = new DateTime(2012, 4, 11),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg",
            };

            var entidadGeneroPelicula = "GeneroPelicula";
            var generoIdPropiedad = "GenerosIdentificador";
            var peliculaIdPropiedad = "PeliculasId";

            var entidadSalaDeCinePelicula = "PeliculaSalaDeCine";
            var salaDeCineIdPropiedad = "SalasDeCineId";

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
                new Dictionary<string, object> { [generoIdPropiedad] = acción.Id, [peliculaIdPropiedad] = avengers.Id },
                new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.Id, [peliculaIdPropiedad] = avengers.Id }
            );

            var coco = new Movie()
            {
                Id = 2,
                Title = "Coco",
                OnBillboard = false,
                ReleaseDate = new DateTime(2017, 11, 22),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg"
            };

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
               new Dictionary<string, object> { [generoIdPropiedad] = animación.Id, [peliculaIdPropiedad] = coco.Id }
           );

            var noWayHome = new Movie()
            {
                Id = 3,
                Title = "Spider-Man: No way home",
                OnBillboard = false,
                ReleaseDate = new DateTime(2021, 12, 17),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
            };

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
               new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.Id, [peliculaIdPropiedad] = noWayHome.Id },
               new Dictionary<string, object> { [generoIdPropiedad] = acción.Id, [peliculaIdPropiedad] = noWayHome.Id },
               new Dictionary<string, object> { [generoIdPropiedad] = comedia.Id, [peliculaIdPropiedad] = noWayHome.Id }
           );

            var farFromHome = new Movie()
            {
                Id = 4,
                Title = "Spider-Man: Far From Home",
                OnBillboard = false,
                ReleaseDate = new DateTime(2019, 7, 2),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
            };

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
               new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.Id, [peliculaIdPropiedad] = farFromHome.Id },
               new Dictionary<string, object> { [generoIdPropiedad] = acción.Id, [peliculaIdPropiedad] = farFromHome.Id },
               new Dictionary<string, object> { [generoIdPropiedad] = comedia.Id, [peliculaIdPropiedad] = farFromHome.Id }
           );

            // Para matrix pongo la fecha en el futuro

            var theMatrixResurrections = new Movie()
            {
                Id = 5,
                Title = "The Matrix Resurrections",
                OnBillboard = true,
                ReleaseDate = new DateTime(2100, 1, 1),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg",
            };

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
              new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
              new Dictionary<string, object> { [generoIdPropiedad] = acción.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
              new Dictionary<string, object> { [generoIdPropiedad] = drama.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id }
          );

            modelBuilder.Entity(entidadSalaDeCinePelicula).HasData(
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine2DSambil.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine3DSambil.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine2DAgora.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine3DAgora.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine2DMegacentro.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine3DMegacentro.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCineCXCMegacentro.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id }
         );


            var keanuReevesMatrix = new MovieActor
            {
                ActorId = keanuReeves.Id,
                MovieId = theMatrixResurrections.Id,
                Order = 1,
                Character = "Neo"
            };

            var avengersChrisEvans = new MovieActor
            {
                ActorId = chrisEvans.Id,
                MovieId = avengers.Id,
                Order = 1,
                Character = "Capitán América"
            };

            var avengersRobertDowney = new MovieActor
            {
                ActorId = robertDowney.Id,
                MovieId = avengers.Id,
                Order = 2,
                Character = "Iron Man"
            };

            var avengersScarlettJohansson = new MovieActor
            {
                ActorId = scarlettJohansson.Id,
                MovieId = avengers.Id,
                Order = 3,
                Character = "Black Widow"
            };

            var tomHollandFFH = new MovieActor
            {
                ActorId = tomHolland.Id,
                MovieId = farFromHome.Id,
                Order = 1,
                Character = "Peter Parker"
            };

            var tomHollandNWH = new MovieActor
            {
                ActorId = tomHolland.Id,
                MovieId = noWayHome.Id,
                Order = 1,
                Character = "Peter Parker"
            };

            var samuelJacksonFFH = new MovieActor
            {
                ActorId = samuelJackson.Id,
                MovieId = farFromHome.Id,
                Order = 2,
                Character = "Samuel L. Jackson"
            };

            modelBuilder.Entity<Movie>().HasData(avengers, coco, noWayHome, farFromHome, theMatrixResurrections);
            modelBuilder.Entity<MovieActor>().HasData(samuelJacksonFFH, tomHollandFFH, tomHollandNWH, avengersRobertDowney, avengersScarlettJohansson,
                avengersChrisEvans, keanuReevesMatrix);

        }

    }
}
