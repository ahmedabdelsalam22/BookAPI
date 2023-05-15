using BookAPI.Data;
using BookAPI.Models;
using BookAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext context;
        public CountryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool CountryExists(int countryId)
        {
            return context.Countries.Any(c=>c.Id == countryId);
        }

        public ICollection<Author> GetAuthorsFromCountry(int countryId)
        {
            return context.Authors.Where(a=>a.Country.Id == countryId).ToList();
        }

        public ICollection<Country> GetCountries()
        {
            return context.Countries.OrderBy(c=>c.Name).ToList();
        }

        public Country GetCountry(int countryId)
        {
            var result = context.Countries.Where(c => c.Id == countryId).FirstOrDefault();
            return result;         
        }

        public Country GetCountryOfAnAuthor(int authorId)
        {
            return context.Authors.Where(a => a.Id == authorId).Select(c=>c.Country).FirstOrDefault();
        }
    }
}
