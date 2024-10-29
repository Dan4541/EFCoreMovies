using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovies.DTOs;
using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ActorsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ActorDTO>> GetAll()
        {
            //return await _context.Actors.ToListAsync();
            /*
            var actors = await _context.Actors.Select(a => new ActorDTO
            {
                Id = a.Id,
                Name = a.Name,

            }).ToListAsync();
            return actors;
            */

            var actors = await _context.Actors.ProjectTo<ActorDTO>(_mapper.ConfigurationProvider).ToListAsync();
            return actors;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterActor(ActorCreationDTO actorCreationDTO)
        {
            var actor = _mapper.Map<Actor>(actorCreationDTO);
            _context.Add(actor);
            await _context.SaveChangesAsync();
            return Ok();

        }

        //Actualizacion de registros - Modelo Conectado 
        [HttpPut("{id:int}")]
        public async Task<ActionResult> EditeActor(ActorCreationDTO actorCreationDTO, int id)
        {
            var actorDB = await _context.Actors.AsTracking().FirstOrDefaultAsync(a => a.Id == id);

            if (actorDB is null)
            {
                return NotFound();
            }

            actorDB = _mapper.Map(actorCreationDTO, actorDB);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Actualizacion de registros - Modelo desconectado 
        [HttpPut("desconectado/{id:int}")]
        public async Task<ActionResult> EditeActor2(ActorCreationDTO actorCreationDTO, int id)
        {
            var actorExists = await _context.Actors.AnyAsync(a => a.Id == id);

            if (!actorExists)
            {
                return NotFound();
            }

            var actor = _mapper.Map<Actor>(actorCreationDTO);
            actor.Id = id;
            _context.Update(actor);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
