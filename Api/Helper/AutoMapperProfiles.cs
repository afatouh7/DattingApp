using Api.Dtos;
using Api.Entity;
using AutoMapper;

namespace Api.Helper
{
    public class AutoMapperProfiles :Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemeberDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url));
                ;
            CreateMap<Photo, PhotoDto>();
        }

    }
}
