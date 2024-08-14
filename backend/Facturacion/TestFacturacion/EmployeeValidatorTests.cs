using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validators;

namespace TestFacturacion
{
    [TestClass]
    public class EmployeeValidatorTests
    {
        Employee employee = new Employee();
        EmployeeValidator validator = new EmployeeValidator();

        [TestMethod]
        public void Validate_ValidData_ReturnsTrue()
        {
            employee.Id = 1;
            employee.Complement = "1-a";
            employee.Name = "Test";

            bool result = validator.Validate(employee);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Validate_IdLesserThanZero_ReturnsFalse()
        {
            employee.Id = 0;
            employee.Complement = "1-a";
            employee.Name = "Test";

            bool result = validator.Validate(employee);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_NameIsNull_ReturnsFalse()
        {
            employee.Id = 1;
            employee.Complement = "1-a";
            employee.Name = string.Empty;

            bool result = validator.Validate(employee);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_NameIsEmptyString_ReturnsFalse()
        {
            employee.Id = 1;
            employee.Complement = "1-a";
            employee.Name = "";

            bool result = validator.Validate(employee);

            Assert.IsFalse(result);
        }
    }
}
