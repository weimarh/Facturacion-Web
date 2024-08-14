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
    public class ShoppingCartRepository : IRepository<ShoppingCart>
    {
        private readonly Context _context;
        public ShoppingCartRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShoppingCart>> GetAllAsync()
        {
            try
            {
                return await _context.ShoppingCarts.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ShoppingCart> GetByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new Exception("Id cannot be 0");
            }

            ShoppingCart? shoppingCart = null;

            try
            {
                shoppingCart = await _context.ShoppingCarts.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (shoppingCart == null)
            {
                throw new Exception("ShoppingCart not found");
            }

            return shoppingCart;
        }

        public async Task<bool> CreateAsync(ShoppingCart entity)
        {
            if (entity == null)
            {
                throw new Exception("ShoppingCart cannot be null");
            }

            try
            {
                await _context.ShoppingCarts.AddAsync(entity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(int id, ShoppingCart entity)
        {
            if (entity == null || id == 0)
                throw new Exception();

            ShoppingCart? shoppingCart = null;

            try
            {
                shoppingCart = await _context.ShoppingCarts.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (shoppingCart == null)
            {
                throw new Exception("ShoppingCart not found");
            }

            try
            {
                _context.Entry(shoppingCart).CurrentValues.SetValues(entity);
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

            ShoppingCart? shoppingCart = null;

            try
            {
                shoppingCart = await _context.ShoppingCarts.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (shoppingCart == null)
            {
                throw new Exception("ShoppingCart not found");
            }

            try
            {
                _context.ShoppingCarts.Remove(shoppingCart);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
