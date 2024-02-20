using AutoMapper;
using BackTask.Database.Entities;
using BackTask.Dto;
using BackTask.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackTask.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private object existingCustomer;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomers()
        {
            try
            {
                var customers = await _customerRepository.GetAllCustomers();
                var customerDtos = _mapper.Map<IEnumerable<CustomerDto>>(customers);
                return Ok(customerDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/customer/{id}
        [HttpGet("customers/{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
        {
            try
            {
                var customer = await _customerRepository.GetCustomerById(id);
                if (customer == null)
                {
                    return NotFound();
                }
                var customerDto = _mapper.Map<CustomerDto>(customer);
                return Ok(customerDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/customer
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> CreateCustomer(CreateCustomerDto customerDto)
        {
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                await _customerRepository.AddCustomer(customer);
                var createdCustomerDto = _mapper.Map<CreateCustomerDto>(customer);
                return Ok(createdCustomerDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<CustomerDto>> UpdateCustomer(UpdateCustomerDto customerDto)
        {
            try
            {
                var existingCustomer = await _customerRepository.GetCustomerById(customerDto.Id);

                if (existingCustomer == null)
                {
                    return NotFound($"Customer with ID {existingCustomer.Id} not found");
                }

                _mapper.Map(customerDto, existingCustomer);

                await _customerRepository.UpdateCustomer(existingCustomer);

                var updatedCustomerDto = _mapper.Map<CustomerDto>(existingCustomer);

                return Ok(updatedCustomerDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            try
            {
                var existingCustomer = await _customerRepository.GetCustomerById(id);

                if (existingCustomer == null)
                {
                    return NotFound($"Customer with ID {id} not found");
                }

                await _customerRepository.DeleteCustomer(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



    }
}

