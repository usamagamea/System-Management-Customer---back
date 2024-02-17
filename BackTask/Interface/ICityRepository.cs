using BackTask.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackTask.Interface
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllCities();
        Task<IEnumerable<City>> GetAllCitiesByCountryId(int countryId);
        Task<IEnumerable<City>> GetCitiesByCountryId(int countryId);
        Task<City> GetCityById(int id);
        Task AddCity(City city);

    }
}
