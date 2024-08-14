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
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly Context _context;
        public CustomerRepository(Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            try
            {
                return await _context.Customers.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            if (id == 0)
                throw new Exception("Id cannot be 0");
          
            Customer? customer = null;

            try
            {
                customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (customer == null)
            {
                throw new Exception("Product not found");
            }

            return customer;
        }

        public async Task<bool> CreateAsync(Customer entity)
        {
            if (entity == null)
            {
                throw new Exception("Customer cannot be null");
            }

            try
            {
                await _context.Customers.AddAsync(entity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(int id, Customer entity)
        {
            if (entity == null || id == 0)
                throw new Exception("Id cannot be 0");

            Customer? customer = null;

            try
            {
                customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            try
            {
                _context.Entry(customer).CurrentValues.SetValues(entity);
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
                throw new Exception("Id cannot be 0");

            Customer? customer = null;

            try
            {
                customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            try
            {
                _context.Customers.Remove(customer);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
