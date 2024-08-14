using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using Validators;

namespace WebView.Controllers
{
    [ApiController]
    [Route("api/customers")]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> _repository;
        private readonly CustomerValidator _customerValidator = new CustomerValidator();

        public CustomerController(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerDTO>> GetAll()
        {
            var customers = await _repository.GetAllAsync();
            return customers.Select(customer => customer.AsDto());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("Id cannot be 0");

            var customer = await _repository.GetByIdAsync(id);

            if (customer == null)
                return NotFound();

            return customer.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> Post(CustomerDTO customerDTO)
        {
            if (customerDTO == null)
                throw new ArgumentNullException("Customer cannot be null");

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

            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer.AsDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, CustomerDTO customerDTO)
        {
            if (id <= 0)
                throw new Exception("Id cannot be zero");

            if (customerDTO == null)
                throw new ArgumentNullException("Customer cannot be null");

            var customerToTupdate = await GetById(id);

            if (customerToTupdate == null)
                throw new Exception("Customer not found");

            Customer customer = new Customer()
            {
                Id = customerDTO.Id,
                Complement = customerDTO.Complement,
                Name = customerDTO.Name,
                Email = customerDTO.Email,
            };

            if (!_customerValidator.Validate(customer))
                throw new Exception("Error updating customer");

            await _repository.UpdateAsync(id, customer);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new Exception("Id cannot be zero");

            var customer = await GetById(id);

            if (customer == null)
                throw new Exception("Customer not found");

            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}
