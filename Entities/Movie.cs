namespace EFCoreMovies.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool OnBillboard { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterURL { get; set; }
        public List<Genre> Genres { get; set; }
        public List<MovieTheater> MovieTheaters { get; set; }
        public List<MovieActor> MoviesActors { get; set; }
    }
}
