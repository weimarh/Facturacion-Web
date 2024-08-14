using DTOs;
using Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using Validators;

namespace WebView.Controllers
{
    [ApiController]
    [Route("api/carts")]
    [Authorize]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly ShoppingCartValidator _shoppingCartValidator = new ShoppingCartValidator();

        public ShoppingCartController(IRepository<ShoppingCart> shoppingCartRepository, IRepository<Customer> customerRepository,
            IRepository<Employee> employeeRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _customerRepository = customerRepository;
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ShoppingCartDTO>> GetAll()
        {
            var shoppingCarts = await _shoppingCartRepository.GetAllAsync();
            return shoppingCarts.Select(ShoppingCart => ShoppingCart.AsDto());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingCartDTO>> GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("Id cannot be 0");

            var shoppingCart = await _shoppingCartRepository.GetByIdAsync(id);

            if (shoppingCart == null)
                return NotFound();

            return shoppingCart.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCartDTO>> Post(CreateShoppingCartDTO shoppingCartDTO)
        {
            if (shoppingCartDTO == null)
                throw new ArgumentNullException("Shopping cart cannot be null");

            decimal totalPrice = ShoppingCartHelpers.CalculateTotalPrice(shoppingCartDTO.orders);

            Customer customer = await _customerRepository.GetByIdAsync(shoppingCartDTO.customerId);
            Employee employee = await _employeeRepository.GetByIdAsync(shoppingCartDTO.employeeId);

            ShoppingCart shoppingCart = new ShoppingCart()
            {
                Orders = shoppingCartDTO.orders,
                TotalPrice = totalPrice,
                CustomerId = shoppingCartDTO.customerId,
                Customer = customer,
                EmployeeId = shoppingCartDTO.employeeId,
                Employee = employee,
            };

            if (!_shoppingCartValidator.Validate(shoppingCart))
                throw new Exception("Error adding the shopping cart");

            await _shoppingCartRepository.CreateAsync(shoppingCart);

            return CreatedAtAction(nameof(GetById), new { id = shoppingCart.Id }, shoppingCart.AsDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, CreateShoppingCartDTO shoppingCart)
        {
            if (id <= 0)
                throw new Exception("Id cannot be zero");

            if (shoppingCart == null)
                throw new Exception("Shopping cart cannot be null");

            ShoppingCart shoppingCartToUpdate = await _shoppingCartRepository.GetByIdAsync(id);

            if (shoppingCartToUpdate == null)
                throw new Exception("Shopping Cart not found");

            decimal totalPrice = ShoppingCartHelpers.CalculateTotalPrice(shoppingCart.orders);

            Customer customer = await _customerRepository.GetByIdAsync(shoppingCart.customerId);
            Employee employee = await _employeeRepository.GetByIdAsync(shoppingCart.employeeId);

            ShoppingCart updatedShoppingCart = new ShoppingCart()
            {
                Orders = shoppingCart.orders,
                TotalPrice = totalPrice,
                CustomerId = customer.Id,
                Customer = customer,
                EmployeeId = employee.Id,
                Employee = employee,
            };

            if (!_shoppingCartValidator.Validate(updatedShoppingCart))
                throw new Exception("Error adding the shopping cart");

            await _shoppingCartRepository.UpdateAsync(id, updatedShoppingCart);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new Exception("Id cannot be zero");

            ShoppingCart shoppingCartToUpdate = await _shoppingCartRepository.GetByIdAsync(id);

            if (shoppingCartToUpdate == null)
                throw new Exception("Shopping Cart not found");

            await _shoppingCartRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
