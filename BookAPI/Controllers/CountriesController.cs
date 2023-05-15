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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCountries()
        {
            var countries = countryRepository.GetCountries().ToList();
            if (countries == null)
            {
                return NotFound("No countries found");
            }
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            List<CountryDto> countryDTO = mapper.Map<List<CountryDto>>(countries);
            
            return Ok(countryDTO);
        }
        [HttpGet("{countryId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCountryById([FromHeader] int countryId) 
        {
            bool countryExists = countryRepository.CountryExists(countryId);
            if (!countryExists) 
            {
                return NotFound("Country not exists");
            }

            var country = countryRepository.GetCountry(countryId);
            
            CountryDto countryDto = mapper.Map<CountryDto>(country);

            return Ok(countryDto);
        }
    }
}
