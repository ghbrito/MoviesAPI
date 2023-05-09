using AutoMapper;
using MoviesAPI.Data.DTOs;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class TheaterProfile : Profile
    {
        public TheaterProfile()
        {
            CreateMap<CreateTheaterDTO, Theater>();
            CreateMap<Theater, ReadTheaterDTO>()
                .ForMember(theaterDto => theaterDto.Address,
                opt => opt.MapFrom(theater => theater.Address))
                .ForMember(theaterDto => theaterDto.Sessions,
                opt => opt.MapFrom(theater => theater.Sessions));
            CreateMap<UpdateTheaterDTO, Theater>();
        }
    }
}
