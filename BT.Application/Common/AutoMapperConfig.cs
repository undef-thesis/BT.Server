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
               cfg.CreateMap<Address, AddressDto>();
           })
            .CreateMapper();

            return config;
        }
    }
}