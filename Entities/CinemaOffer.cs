namespace EFCoreMovies.Entities
{
    public class CinemaOffer
    {
        public int Id { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public decimal discountPercentage { get; set; }
        public int CinemaId { get; set; }
    }
}
