using BackTask.Database;
using BackTask.Database.Entities;
using BackTask.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackTask.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly TaskDbContext _context;

        public CustomerRepository(TaskDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _context.Customers.Include(x => x.City).Include(x => x.Country).ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _context.Customers.Include(x => x.City).Include(x => x.Country).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }
    }
}
