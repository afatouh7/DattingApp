using Api.Dtos;
using Api.Entity;
using Api.Extensions;
using AutoMapper;

namespace Api.Helper
{
    public class AutoMapperProfiles :Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemeberDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => 
                src.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest=>dest.Age,opt=>opt.MapFrom(src=>src.DateOfBirth.CalculateAge()));
                
            CreateMap<Photo, PhotoDto>();
        }

    }
}
