using System.ComponentModel.DataAnnotations;

namespace EFCoreMovies.DTOs
{
    public class CinemaCreationDTO
    {
        [Required]
        public string Name { get; set; }
        public double Latidud { get; set; }
        public double Longidud { get; set; }
        public CinemaOfferDTO CinemaOffer { get; set; }
        public MovieTheaterDTO[] MovieTheaters { get; set; }
    }
}
