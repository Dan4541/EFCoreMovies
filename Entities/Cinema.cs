using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace EFCoreMovies.Entities
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //[Precision(precision:9, scale:2)]
        public Point Ubication { get; set; }
        public CinemaOffer CinemaOffer { get; set; }
        public HashSet<MovieTheater> MovieTheaters { get; set; }

    }
}
