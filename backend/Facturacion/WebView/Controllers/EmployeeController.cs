using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using Validators;

namespace WebView.Controllers
{
    [ApiController]
    [Route("api/employees")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository<Employee> _repository;
        private readonly EmployeeValidator _employeeValidator = new EmployeeValidator();

        public EmployeeController(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeDTO>> GetAll()
        {
            var employees = await _repository.GetAllAsync();
            return employees.Select(Employee => Employee.AsDto());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("Id cannot be 0");

            var employee = await _repository.GetByIdAsync(id);

            if (employee == null)
                return NotFound();

            return employee.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> Post(EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null)
                throw new ArgumentNullException("Empoyee cannot be null");

            Rol rol = (Rol)Enum.Parse(typeof(Rol), employeeDTO.Rol);

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

            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee.AsDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, EmployeeDTO employeeDTO)
        {
            if (id <= 0)
                throw new ArgumentNullException("Id cannot be 0");

            if (employeeDTO == null)
                throw new ArgumentNullException("Employee cannot be null");

            var employeeToUpdate = await GetById(id);

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

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("Id cannot be 0");

            var employee = await GetById(id);

            if (employee == null)
                throw new Exception("Employee not found");

            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}
