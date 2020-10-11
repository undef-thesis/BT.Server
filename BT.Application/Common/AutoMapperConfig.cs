using AutoMapper;
using BT.Application.DTO;
using BT.Domain.Domain;

namespace BT.Application.Common
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
           {
                cfg.CreateMap<Meeting, MeetingDto>();
                cfg.CreateMap<Meeting, MeetingDetailsDto>();
                cfg.CreateMap<MeetingImage, MeetingImageDto>();
                cfg.CreateMap<Address, AddressDto>();
                cfg.CreateMap<Comment, CommentDto>();
                cfg.CreateMap<Category, CategoryDto>();
                cfg.CreateMap<User, UserPofileDto>();
                cfg.CreateMap<City, CityDto>();
           })
            .CreateMapper();

            return config;
        }
    }
}