using AutoMapper;
using MoviesAPI.Data.DTOs;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<CreateMovieDTO, Movie>();
            CreateMap<UpdateMovieDTO, Movie>();
            CreateMap<Movie, UpdateMovieDTO>();
            CreateMap<Movie, ReadMovieDTO>();
            CreateMap<Movie, ReadMovieDTO>()
                .ForMember(movieDto => movieDto.Sessions,
                opt => opt.MapFrom(movie => movie.Sessions));
        }
    }
}