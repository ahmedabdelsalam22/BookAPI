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
        public IActionResult GetCountryById(int countryId)
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

        [HttpGet("authors/{authorId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCountryOfAnAuthor(int authorId)
        {
            var country = countryRepository.GetCountryOfAnAuthor(authorId);
            if (country == null)
            {
                return NotFound("No country exists with this author!");
            }
            var countryDto = mapper.Map<CountryDto>(country);
            return Ok(countryDto);
        }

        [HttpGet("{countryId}/authors")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAuthorsByCountry(int countryId) 
        {
            var authors = countryRepository.GetAuthorsFromCountry(countryId).ToList();
            if (authors == null) 
            {
                return NotFound("No authors exists with this country");
            }
            List<AuthorDto> authorDto = mapper.Map<List<AuthorDto>>(authors);

            return Ok(authorDto);
        }
    }
}
