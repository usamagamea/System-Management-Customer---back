using BackTask.Database;
using BackTask.Database.Entities;
using BackTask.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackTask.Implementation
{
    public class CityRepository : ICityRepository
    {
        private readonly TaskDbContext _context;

        public CityRepository(TaskDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<IEnumerable<City>> GetAllCitiesByCountryId(int countryId)
        {
            return await _context.Cities.Include(x => x.Country).Where(c => c.CountryId  == countryId).ToListAsync();
        }

        public async Task<IEnumerable<City>> GetCitiesByCountryId(int countryId)
        {
            return await _context.Cities.Include(x => x.Country).Where(c => c.CountryId == countryId).ToListAsync();
        }

        public async Task<City> GetCityById(int id)
        {
            return await _context.Cities.FindAsync(id);
        }

        public async Task AddCity(City city)
        {
            if (_context.Cities.Any(c => c.Name == city.Name))
            {
                throw new Exception("City with the same name already exists.");
            }
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
        }
    }
}
