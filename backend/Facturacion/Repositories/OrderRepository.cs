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
    public class OrderRepository : IRepository<Order>
    {
        private readonly Context _context;
        public OrderRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            try
            {
                return await _context.Orders.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new Exception("Id cannot be 0");
            }

            Order? order = null;

            try
            {
                order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            return order;
        }

        public async Task<bool> CreateAsync(Order entity)
        {
            if (entity == null)
            {
                throw new Exception("Order cannot be null");
            }

            try
            {
                await _context.Orders.AddAsync(entity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(int id, Order entity)
        {
            if (entity == null || id == 0)
                throw new Exception();

            Order? order = null;

            try
            {
                order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            try
            {
                _context.Entry(order).CurrentValues.SetValues(entity);
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

            Order? order = null;

            try
            {
                order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            try
            {
                _context.Orders.Remove(order);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
