using Connection;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly Context _context;
        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            try
            {
                return await _context.Products.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new Exception("Id cannot be 0");
            }

            Product? product = null;

            try
            {
                product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (product == null)
            {
                throw new Exception("Product not found");
            }

            return product;
        }

        public async Task<bool> CreateAsync(Product entity)
        {
            if (entity == null)
            {
                throw new Exception("Product cannot be null");
            }

            try
            {
                await _context.Products.AddAsync(entity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(int id, Product entity)
        {
            if (entity == null || id == 0)
                throw new Exception();

            Product? product = null;

            try
            {
                product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (product == null)
            {
                throw new Exception("Product not found");
            }

            try
            {
                _context.Entry(product).CurrentValues.SetValues(entity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (id == 0)
                throw new Exception();

            Product? product = null;

            try
            {
                product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (product == null)
            {
                throw new Exception("Product not found");
            }

            try
            {
                _context.Products.Remove(product);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
