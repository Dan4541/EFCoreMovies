using AutoMapper;
using EFCoreMovies.DTOs;
using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MoviesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MovieDTO>> GetById(int id)
        {
            var movie =  _context.Movies
                .Include(g => g.Genres)
                .Include(mt => mt.MovieTheaters)
                    .ThenInclude(c => c.Cinema)
                .Include(m => m.MoviesActors)
                    .ThenInclude(ma => ma.Actor)
                .FirstOrDefault(m => m.Id == id);

            if (movie is null)
            {
                return NotFound();
            }

            var movieDTO = _mapper.Map<MovieDTO>(movie);
            movieDTO.Cines = movieDTO.Cines.DistinctBy(c => c.Id).ToList();

            return movieDTO;
        }

        [HttpGet("groupbypremiere")]
        public async Task<ActionResult> GetGroupByBillboard()
        {
            var moviesGrouped = await _context.Movies.GroupBy(p => p.OnBillboard)
                .Select(g => new
                {
                    OnBillboard = g.Key,
                    Counting = g.Count(),
                    Movies = g.ToList()
                }).ToListAsync();

            return Ok(moviesGrouped);
        }

        [HttpGet("groupbygenresamount")]
        public async Task<ActionResult> GetGroupByGenresAmount()
        {
            var moviesGrouped = await _context.Movies.GroupBy(m => m.Genres.Count())
                .Select(g => new
                {
                    Counting = g.Key,
                    Titles = g.Select(m => m.Title),
                    Genres = g.Select(m => m.Genres).SelectMany(genre => genre).Select(genre => genre.Name).Distinct()
                }).ToListAsync();

            return Ok(moviesGrouped);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<List<MovieDTO>>> Filter([FromQuery] MovieFilterDTO movieFilter)
        {
            var moviesQueryable = _context.Movies.AsQueryable();

            if (!string.IsNullOrEmpty(movieFilter.Title))
            {
                moviesQueryable = moviesQueryable.Where(m => m.Title.Contains(movieFilter.Title));
            }

            if (movieFilter.OnBillboard)
            {
                moviesQueryable = moviesQueryable.Where(m => m.OnBillboard);
            }

            if (movieFilter.UpcomingReleases)
            {
                var today = DateTime.Today;
                moviesQueryable = moviesQueryable.Where(m => m.ReleaseDate > today);
            }

            if (movieFilter.GenreId != 0)
            {
                moviesQueryable = moviesQueryable.Where(m => m.Genres.Select(g => g.Id).Contains(movieFilter.GenreId));
            }

            var movies = await moviesQueryable.Include(m => m.Genres).ToListAsync();

            return _mapper.Map<List<MovieDTO>>(movies);
        }

        //Con datos relacionales existentes
        [HttpPost]
        public async Task<ActionResult> RegisterMovie(MovieCreationDTO movieCreationDTO)
        {
            var movie = _mapper.Map<Movie>(movieCreationDTO);
            movie.Genres.ForEach(g => _context.Entry(g).State = EntityState.Unchanged);
            movie.MovieTheaters.ForEach(mt => _context.Entry(mt).State = EntityState.Unchanged);

            if(movie.MoviesActors is not null)
            {
                for (int i = 0; i < movie.MoviesActors.Count(); i++)
                {
                    movie.MoviesActors[i].OrderMA = i + 1;
                }
            }

            _context.Add(movie);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
    }
}
