using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        public readonly ApplicationDbContext _context;

        public GenresController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Genre>> GetAll()
        {
            _context.Logs.Add(new Log() { Message = "Get all genres list"});
            await _context.SaveChangesAsync();
            return await _context.Genres.ToListAsync();
        }

        [HttpGet("primer")]
        public async Task<ActionResult<Genre>> Primer()
        {
            //return await _context.Genres.FirstAsync();
            //return await _context.Genres.FirstAsync(g => g.Name.StartsWith("C"));
            var genre = await _context.Genres.FirstOrDefaultAsync();

            if (genre is null)
            {
                return NotFound();
            }

            return genre;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genre>> GetById(int id)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == id);
            //var genre = await _context.Genres.Where(g => !g.IsDeleted).FirstOrDefaultAsync(g => g.Id == id);
            if (genre is null)
            {
                return NotFound();
            }

            return genre;
        }

        [HttpGet("filter")]
        public async Task<IEnumerable<Genre>> FilterGenres(string name)
        {
            //return await _context.Genres.Where(g => g.Name.StartsWith("C")).ToListAsync();
            return await _context.Genres.Where(g => g.Name.Contains(name)).ToListAsync();
        }

        [HttpGet("pagination")]
        public async Task<ActionResult<IEnumerable<Genre>>> GetPagination()
        {
            var genres = await _context.Genres.Take(2).ToListAsync();
            return genres;
        }
        /*
        [HttpPost]
        public async Task<ActionResult> RegisterGenre(Genre genre)
        {
            var status1 = _context.Entry(genre).State;
            _context.Add(genre);
            var status2 = _context.Entry(genre).State;
            await _context.SaveChangesAsync();
            var status3 = _context.Entry(genre).State;

            return Ok();
        }
        */

        [HttpPost]
        public async Task<ActionResult> RegisterGenreIndexEfficient(Genre genre)
        {
            var genreExistsName = await _context.Genres.AnyAsync(g => g.Name == genre.Name);

            if (genreExistsName)
            {
                return BadRequest("The Genre you're trying to add already exists " + genre.Name);
            }

            _context.Add(genre);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("several")]
        public async Task<ActionResult> RegisterSeveralGenre(Genre[] genres)
        {
            _context.AddRange(genres);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteGenre(int id)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == id);

            if (genre is null)
            {
                return NotFound();
            }

            _context.Remove(genre);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("softdelete/{id:int}")]
        public async Task<ActionResult> SoftDeleteGenre(int id)
        {
            var genre = await _context.Genres.AsTracking().FirstOrDefaultAsync(g => g.Id == id);

            if (genre is null)
            {
                return NotFound();
            }

            genre.IsDeleted = true;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("restore/{id:int}")]
        public async Task<ActionResult> RestoreDeletedGenre(int id)
        {
            var genre = await _context.Genres.AsTracking()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(g => g.Id == id);

            if (genre is null)
            {
                return NotFound();
            }

            genre.IsDeleted = false;
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
