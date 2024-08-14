using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using Validators;

namespace WebView.Controllers
{
    [ApiController]
    [Route("api/products")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _repository;
        private readonly ProductValidator _validator = new ProductValidator();
        public ProductController(IRepository<Product> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var products = await _repository.GetAllAsync();
            return products.Select(product => product.AsDto());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("Id cannot be 0");

            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return product.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Post(ProductDTO productDTO)
        {
            if (productDTO == null)
                throw new ArgumentNullException("Product cannot be null");

            Category category = (Category)Enum.Parse(typeof(Category), productDTO.Category);

            IEnumerable<ProductDTO> prods = await GetAll();
            List<string> names = new List<string>();

            foreach (var item in prods)
            {
                names.Add(item.Name);
            }

            if (_validator.DuplicateValidator(productDTO.Name, names))
                throw new Exception("Product already exists");

            Product product = new Product()
            {
                Name = productDTO.Name,
                Category = category,
                Description = productDTO.Description,
                Price = productDTO.Price,
            };

            if (!_validator.CreateValidator(product))
                throw new Exception("Error adding product");

            await _repository.CreateAsync(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product.AsDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, ProductDTO productDTO)
        {
            if (id <= 0)
                throw new Exception("Id cannot be zero");

            if (productDTO == null)
                throw new ArgumentNullException("Product cannot be null");

            var productToUpdate = await GetById(id);

            if (productToUpdate == null)
                throw new Exception("Product not found");

            IEnumerable<ProductDTO> prods = await GetAll();
            List<string> names = new List<string>();

            foreach (var item in prods)
            {
                names.Add(item.Name);
            }

            if (_validator.DuplicateValidator(productDTO.Name, names))
                throw new Exception("Product already exists");

            Category category = (Category)Enum.Parse(typeof(Category), productDTO.Category);

            Product product = new Product()
            {
                Name = productDTO.Name,
                Category = category,
                Description = productDTO.Description,
                Price = productDTO.Price,
            };

            if (!_validator.UpdateValidator(product))
                throw new Exception("Error updating product");

            await _repository.UpdateAsync(id, product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new Exception("Id cannot be zero");

            var product = await GetById(id);

            if (product == null)
                throw new Exception("Product not found");

            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}
