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
    [Route("api/orders")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IRepository<Order> _repository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly OrderValidator _orderValidator = new OrderValidator();

        public OrderController(IRepository<Order> repository, IRepository<Product> productRepository,
            IRepository<ShoppingCart> shoppingCartRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderDTO>> GetAll()
        {
            var orders = await _repository.GetAllAsync();
            return orders.Select(order => order.AsDto());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("Id cannot be 0");

            var order = await _repository.GetByIdAsync(id);

            if(order == null)
                return NotFound();

            return order.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post(CreateOrderDTO orderDTO)
        {
            if (orderDTO == null)
                throw new ArgumentNullException("Order cannot be null");

            Product product = await _productRepository.GetByIdAsync(orderDTO.ProductId);
            ShoppingCart shoppingCart = await _shoppingCartRepository.GetByIdAsync(orderDTO.ShoppingCartId);

            Order order = new Order()
            {
                ProductId = orderDTO.ProductId,
                Product = product,
                Quantity = orderDTO.Quantity,
                PartialPrice = OrderHelpers.CalculatePartialPrice(orderDTO.Quantity, product.Price),
                ShoppingCartId = orderDTO.ShoppingCartId,
                ShoppingCart = shoppingCart,
            };

            if (!_orderValidator.CreateValidator(order))
                throw new Exception("Error Adding order");

            await _repository.CreateAsync(order);

            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order.AsDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, int quantity)
        {
            if (id <= 0)
                throw new Exception("Id cannot be zero");

            if (quantity <= 0)
                throw new Exception("Quantity must be greater than 0");

            Order orderToUpdate = await _repository.GetByIdAsync(id);

            if (orderToUpdate == null)
                throw new Exception("Order not found");

            Order updatedOrder = new Order()
            {
                ProductId = orderToUpdate.ProductId,
                Product = orderToUpdate.Product,
                Quantity = quantity,
                ShoppingCartId = orderToUpdate.ShoppingCartId,
                ShoppingCart = orderToUpdate.ShoppingCart,
            };

            if (!_orderValidator.UpdateValidator(updatedOrder))
                throw new Exception("Error updating order");

            await _repository.UpdateAsync(id, updatedOrder);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new Exception("Id cannot be zero");

            Order order = await _repository.GetByIdAsync(id);

            if (order == null)
                throw new Exception("Order not found");

            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}
