using DTOs;
using Microsoft.Identity.Client;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validators;

namespace Controllers
{
    public class CustomerController
    {
        private readonly IRepository<Customer> _repository;
        private CustomerValidator _customerValidator;

        public CustomerController(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAll()
        {
            var customers = await _repository.GetAllAsync();
            return customers.Select(customer => customer.AsDto());
        }

        public async Task<CustomerDTO> GetById(int id)
        {
            if(id <= 0)
                throw new ArgumentNullException("Id cannot be 0");

            var product = await _repository.GetByIdAsync(id);
            return product.AsDto();
        }

        public async Task<CustomerDTO> Post(CustomerDTO customerDTO)
        {
            if (customerDTO == null) 
                throw new ArgumentNullException("Customer cannot be null");

            _customerValidator = new CustomerValidator();

            Customer customer = new Customer()
            {
                Id = customerDTO.Id,
                Complement = customerDTO.Complement,
                Name = customerDTO.Name,
                Email = customerDTO.Email,
            };

            if (!_customerValidator.Validate(customer))
                throw new Exception("Error adding customer");

            await _repository.CreateAsync(customer);

            return customer.AsDto();
        }

        public async Task Put(int id, CustomerDTO customerDTO)
        {
            _customerValidator = new CustomerValidator();

            if (id <= 0)
                throw new Exception("Id cannot be zero");

            if (customerDTO == null)
                throw new ArgumentNullException("Customer cannot be null");

            CustomerDTO customerToTupdate = await GetById(id);

            if (customerToTupdate == null)
                throw new Exception("Customer not found");

            Customer customer = new Customer()
            {
                Id = customerDTO.Id,
                Complement = customerDTO.Complement,
                Name = customerDTO.Name,
                Email= customerDTO.Email,
            };

            if (!_customerValidator.Validate(customer))
                throw new Exception("Error updating customer");

            await _repository.UpdateAsync(id, customer);
        }

        public async Task Delete(int id)
        {
            if (id <= 0)
                throw new Exception("Id cannot be zero");

            CustomerDTO customer = await GetById(id);

            if (customer == null)
                throw new Exception("Customer not found");

            await _repository.DeleteAsync(id);
        }
    }
}
