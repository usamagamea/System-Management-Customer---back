using BackTask.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackTask.Interface
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        Task AddCustomer(Customer customer);
    }
}
