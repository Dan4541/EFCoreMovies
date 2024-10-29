namespace EFCoreMovies.DTOs
{
    public class MovieFilterDTO
    {
        public int GenreId { get; set; }
        public string Title { get; set; }
        public bool OnBillboard { get; set; }
        public bool UpcomingReleases { get; set; }

    }
}
