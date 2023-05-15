using BookAPI.Models;

namespace BookAPI.Repository.IRepository
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int countryId);
        Country GetCountryOfAnAuthor(int authorId);
        ICollection<Author> GetAuthorsFromCountry(int countryId);
        bool CountryExists(int countryId);
    }
}
