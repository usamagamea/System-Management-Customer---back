using BackTask.Database.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackTask.Interface
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        Task AddCustomer(Customer customer);

        Task UpdateCustomer(Customer customer);

        Task DeleteCustomer(int id);
     
    }
}
