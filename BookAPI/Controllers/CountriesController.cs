using AutoMapper;
using BookAPI.Dtos;
using BookAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository countryRepository;
        private readonly IMapper mapper;

        public CountriesController(ICountryRepository countryRepository, IMapper mapper)
        {
            this.countryRepository = countryRepository;
            this.mapper = mapper;
        }

        [HttpGet("allCountries")]
        public IActionResult GetCountries()
        {
            var countries = countryRepository.GetCountries().ToList();

            List<CountryDto> countryDTO = mapper.Map<List<CountryDto>>(countries);

            if (countryDTO == null) 
            {
                return NotFound("No countries found");
            }
            return Ok(countryDTO);
        }
    }
}
