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
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly Context _context;
        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            try
            {
                return await _context.Employees.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            if (id == 0)
                throw new Exception("Id cannot be 0");

            Employee? employee = null;

            try
            {
                employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (employee == null)
            {
                throw new Exception("Employee not found");
            }

            return employee;
        }

        public async Task<bool> CreateAsync(Employee entity)
        {
            if (entity == null)
            {
                throw new Exception("Employee cannot be null");
            }

            try
            {
                await _context.Employees.AddAsync(entity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(int id, Employee entity)
        {
            if (entity == null || id == 0)
                throw new Exception("Id cannot be 0");

            Employee? employee = null;

            try
            {
                employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (employee == null)
            {
                throw new Exception("Employee not found");
            }

            try
            {
                _context.Entry(employee).CurrentValues.SetValues(entity);
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

            Employee? employee = null;

            try
            {
                employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (employee == null)
            {
                throw new Exception("Employee not found");
            }

            try
            {
                _context.Employees.Remove(employee);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return await _context.SaveChangesAsync() > 0;
        }
    }

}
