namespace EFCoreMovies.Entities
{
    public class MovieTheater
    {
        public int Id { get; set; }
        public MovieTheaterType TheaterType { get; set; }
        public decimal Price { get; set; }
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
