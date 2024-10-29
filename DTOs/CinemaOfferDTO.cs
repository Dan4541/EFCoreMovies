using System.ComponentModel.DataAnnotations;

namespace EFCoreMovies.DTOs
{
    public class CinemaOfferDTO
    {
        [Range(1, 100)]
        public double discountPercentage { get; set; }
        public DateTime starDate { get; set; }
        public DateTime endDate { get; set; }  
    }
}
