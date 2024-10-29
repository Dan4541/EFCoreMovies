using EFCoreMovies.Entities;

namespace EFCoreMovies.DTOs
{
    public class MovieTheaterDTO
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public MovieTheaterType MovieTheaterType { get; set; }
    }
}
