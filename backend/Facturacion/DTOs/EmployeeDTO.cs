using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public record class EmployeeDTO([Required] int Id, string? Complement, [Required] string? Name, [Required] string? Rol);
}
