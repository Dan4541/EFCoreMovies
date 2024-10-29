using AutoMapper;
using EFCoreMovies.DTOs;
using EFCoreMovies.Entities;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCoreMovies.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Actor, ActorDTO>();
            CreateMap<Cinema, CinemaDTO>()
                .ForMember(dto => dto.Latitud, ent => ent.MapFrom(prop => prop.Ubication.Y))
                .ForMember(dto => dto.Longitud, ent => ent.MapFrom(prop => prop.Ubication.X));

            CreateMap<Genre, GenreDTO>();
            CreateMap<Movie, MovieDTO>()
                .ForMember(dto => dto.Cines, ent => ent.MapFrom(prop => prop.MovieTheaters.Select(s => s.Cinema)))
                .ForMember(dto => dto.Actors, ent => ent.MapFrom(prop => prop.MoviesActors.Select(ma => ma.Actor)));

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            CreateMap<CinemaCreationDTO, Cinema>()
                .ForMember(ent => ent.Ubication, dto => dto.MapFrom(field => geometryFactory.CreatePoint(new Coordinate(field.Longidud, field.Latidud))));

            CreateMap<CinemaOfferDTO, CinemaOffer>();
            CreateMap<MovieTheaterDTO, MovieTheater>();

            CreateMap<MovieCreationDTO, Movie>()
                .ForMember(ent => ent.Genres, dto => dto.MapFrom(f => f.Genres.Select(id => new Genre() { Id = id })))
                .ForMember(ent => ent.MovieTheaters, dto => dto.MapFrom(f => f.MovieTheater.Select(id => new MovieTheater() { Id = id })));

            CreateMap<MovieActorCreationDTO, MovieActor>();

            CreateMap<ActorCreationDTO, Actor>();
        }
    }
}
