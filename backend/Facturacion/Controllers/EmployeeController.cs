using DTOs;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validators;

namespace Controllers
{
    public class EmployeeController
    {
        private readonly IRepository<Employee> _repository;
        private EmployeeValidator _employeeValidator;

        public EmployeeController(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAll()
        {
            var employees = await _repository.GetAllAsync();
            return employees.Select(employee => employee.AsDto());
        }

        public async Task<EmployeeDTO> GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("Id cannot be 0");

            var employee = await _repository.GetByIdAsync(id);
            return employee.AsDto();
        }

        public async Task<EmployeeDTO> Post(EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null) 
                throw new ArgumentNullException("Empoyee cannot be null");

            _employeeValidator = new EmployeeValidator();

            Rol rol = (Rol) Enum.Parse(typeof(Rol), employeeDTO.Rol);

            Employee employee = new Employee()
            {
                Id = employeeDTO.Id,
                Complement = employeeDTO.Complement,
                Name = employeeDTO.Name,
                Rol = rol,
            };

            if (!_employeeValidator.Validate(employee))
                throw new Exception("Error adding employee");

            await _repository.CreateAsync(employee);

            return employee.AsDto();
        }

        public async Task Put(int id, EmployeeDTO employeeDTO)
        {
            _employeeValidator = new EmployeeValidator();

            if (id <= 0)
                throw new ArgumentNullException("Id cannot be 0");

            if (employeeDTO == null)
                throw new ArgumentNullException("Employee cannot be null");

            EmployeeDTO employeeToUpdate = await GetById(id);

            if (employeeToUpdate == null)
                throw new Exception("Employee not found");

            Rol rol = (Rol)Enum.Parse(typeof(Rol), employeeDTO.Rol);

            Employee employee = new Employee()
            {
                Id = employeeDTO.Id,
                Complement = employeeDTO.Complement,
                Name = employeeDTO.Name,
                Rol = rol,
            };

            if (!_employeeValidator.Validate(employee))
                throw new Exception("Error updating employee");

            await _repository.UpdateAsync(id, employee);
        }

        public async Task Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("Id cannot be 0");

            EmployeeDTO employee = await GetById(id);

            if (employee == null)
                throw new Exception("Employee not found");

            await _repository.DeleteAsync(id);
        }
    }
}
