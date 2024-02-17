using BackTask.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackTask.Interface
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<Country> GetCountryById(int id);
        Task AddCountry(Country country);
    }
}
