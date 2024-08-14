using DTOs;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Validators;

namespace Controllers
{
    public class ProductController
    {
        private readonly IRepository<Product> _repository;
        private ProductValidator? _validator;
        public ProductController(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var products = await _repository.GetAllAsync();
            return products.Select(p => p.AsDto());
        }

        public async Task<ProductDTO> GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("Id cannot be 0");

            var product = await _repository.GetByIdAsync(id);
            return product.AsDto();
        }

        public async Task<ProductDTO> Post(ProductDTO productDTO)
        {
            if (productDTO == null)
                throw new ArgumentNullException("Product cannot be null");

            _validator = new ProductValidator();

            Category category = (Category) Enum.Parse(typeof(Category), productDTO.Category);

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

            return product.AsDto();
        }

        public async Task Put(int id, ProductDTO productDTO)
        {
            _validator = new ProductValidator();

            if (id <= 0)
                throw new Exception("Id cannot be zero");

            if (productDTO == null)
                throw new ArgumentNullException("Product cannot be null");

            ProductDTO? productToUpdate = await GetById(id);

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

            if(!_validator.UpdateValidator(product))
                throw new Exception("Error updating product");

            await _repository.UpdateAsync(id, product);
        }

        public async Task Delete(int id)
        {
            if (id <= 0)
                throw new Exception("Id cannot be zero");

            ProductDTO? product = await GetById(id);

            if (product == null)
                throw new Exception("Product not found");

            await _repository.DeleteAsync(id);
        }
    }
}
