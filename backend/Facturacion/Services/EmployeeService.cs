using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repository;
        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task<List<Employee>> Employees()
        {
            return (await _repository.GetAllAsync()).ToList();
        }

        public async Task<bool> isEmployee(int id, string? name)
        {
            int count = 0;

            List<Employee> employees = await Employees();

            foreach (var employee in employees)
            {
                if (employee.Id == id && employee.Name == name)
                    count++;
            }

            return count > 0;
        }
    }
}
