using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators
{
    public class EmployeeValidator 
    {
        public bool Validate(Employee employee)
        {
            bool isValid = false;

            if (employee.Id > 0 && employee.Name != string.Empty && employee.Name != "")
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
