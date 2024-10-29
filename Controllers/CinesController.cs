using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovies.DTOs;
using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/cines")]
    public class CinesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CinesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CinemaDTO>> GetAll()
        {
            return await _context.Cines.ProjectTo<CinemaDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpGet("nearest")]
        public async Task<ActionResult> GetNearest(double latitud, double longitud)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var myUbication = geometryFactory.CreatePoint(new Coordinate(latitud, longitud));

            var cines = await _context.Cines
                .OrderBy(c => c.Ubication.Distance(myUbication))
                .Select(c => new
                {
                    Name = c.Name,
                    Ubication = Math.Round(c.Ubication.Distance(myUbication))
                }).ToListAsync();
            return Ok(cines);
        }

        [HttpPost]
        public async Task<ActionResult> RegisterCinemaWithRelationships()
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var myUbication = geometryFactory.CreatePoint(new Coordinate(-70.269573, 19.925743));

            var cinema = new Cinema()
            {
                Name = "Paseo Metropoli",
                Ubication = myUbication,
                CinemaOffer = new CinemaOffer()
                {
                    discountPercentage = 5,
                    startDate = DateTime.Today,
                    endDate = DateTime.Today.AddDays(7)
                },
                MovieTheaters = new HashSet<MovieTheater>()
                {
                    new MovieTheater()
                    {
                        Price = 250,
                        TheaterType = MovieTheaterType.TwoDimensions
                    },
                    new MovieTheater()
                    {
                        Price = 380,
                        TheaterType = MovieTheaterType.ThreeDimensions
                    },

                    new MovieTheater()
                    {
                        Price = 300,
                        TheaterType = MovieTheaterType.CxC
                    }
                }
            };

            _context.Add(cinema);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Sin datos relacionales existentes
        [HttpPost("withDTO")]
        public async Task<ActionResult> RegisterCinemaWithRelationshipsDTO(CinemaCreationDTO cinema)
        {
            var cine = _mapper.Map<Cinema>(cinema);
            _context.Add(cine);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> EditeCinema(CinemaCreationDTO cinemaCreationDTO, int id)
        {
            var cineDB = await _context.Cines.AsTracking()
                        .Include(c => c.MovieTheaters)
                        .Include(c => c.CinemaOffer)
                        .FirstOrDefaultAsync(c => c.Id == id);

            if (cineDB is null)
            {
                return NotFound();
            }

            cineDB = _mapper.Map(cinemaCreationDTO, cineDB);
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> VisualizeEditeCinema(int id)
        {
            var cineDB = await _context.Cines.AsTracking()
                        .Include(c => c.MovieTheaters)
                        .Include(c => c.CinemaOffer)
                        .FirstOrDefaultAsync(c => c.Id == id);

            if (cineDB is null)
            {
                return NotFound();
            }

            cineDB.Ubication = null;
            return Ok(cineDB);
        }



    }
}
