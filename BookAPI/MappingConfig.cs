using AutoMapper;
using BookAPI.Dtos;
using BookAPI.Models;

namespace BookAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Country,CountryDto>();
        }
    }
}
