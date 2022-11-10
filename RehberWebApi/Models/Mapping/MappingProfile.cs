using AutoMapper;
using RehberWebApi.Models.Dtos;
using RehberWebApi.Models.Entities;

namespace RehberWebApi.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RehberDto, Rehber>();
        }
    }
}
