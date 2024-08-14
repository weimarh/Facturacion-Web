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
    public class CustomerValidatorTests
    {
        Customer customer = new Customer();
        CustomerValidator validator = new CustomerValidator();

        [TestMethod]
        public void Validate_ValidData_ReturnsTrue()
        {
            customer.Id = 1;
            customer.Complement = "1-a";
            customer.Name = "Test";
            customer.Email = "Test";

            bool result = validator.Validate(customer);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Validate_IdLesserThanZero_ReturnsFalse()
        {
            customer.Id = 0;
            customer.Complement = "1-a";
            customer.Name = "Test";
            customer.Email = "Test";

            bool result = validator.Validate(customer);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_NameIsNull_ReturnsFalse()
        {
            customer.Id = 1;
            customer.Complement = "1-a";
            customer.Name = string.Empty;
            customer.Email = "Test";

            bool result = validator.Validate(customer);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_NameIsEmptyString_ReturnsFalse()
        {
            customer.Id = 1;
            customer.Complement = "1-a";
            customer.Name = "";
            customer.Email = "Test";

            bool result = validator.Validate(customer);

            Assert.IsFalse(result);
        }
    }
}
