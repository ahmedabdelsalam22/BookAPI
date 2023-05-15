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

        public CountriesController(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        [HttpGet("allCountries")]
        public IActionResult GetCountries()
        {
            var countries = countryRepository.GetCountries().ToList();
            if (countries == null) 
            {
                return NotFound("No countries found");
            }
            return Ok(countries);
        }
    }
}
