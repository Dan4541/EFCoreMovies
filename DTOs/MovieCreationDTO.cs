﻿namespace EFCoreMovies.DTOs
{
    public class MovieCreationDTO
    {
        public string Title { get; set; }
        public bool OnBillboard { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<int> Genres { get; set; }
        public List<int> MovieTheater { get; set; }
        public List<MovieActorCreationDTO> MoviesActors { get; set; }
    }
}
