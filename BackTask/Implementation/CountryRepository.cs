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
    public class CountryRepository : ICountryRepository
    {
        private readonly TaskDbContext _context;

        public CountryRepository(TaskDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetCountryById(int id)
        {
            return await _context.Countries.FindAsync(id);
        }

        public async Task AddCountry(Country country)
        {
            if (_context.Countries.Any(c => c.Name == country.Name))
            {
                throw new InvalidOperationException("Country with the same name already exists.");
            }
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
        }


    }
}
