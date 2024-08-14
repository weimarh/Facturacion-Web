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
    public class ShoppingCartValidatorTests
    {
        private readonly ShoppingCartValidator _shoppingCartValidator = new ShoppingCartValidator();
        private readonly ShoppingCart _shoppingCart = new ShoppingCart();
        private readonly List<Order> _orders = new List<Order>();
        private readonly Customer _customer = new Customer();
        private readonly Employee _employee = new Employee();


        [TestMethod]
        public void Validate_ValidData_ReturnsTrue()
        {
            _orders.Add(new Order());
            _orders.Add(new Order());
            _orders.Add(new Order());

            _shoppingCart.Orders = _orders;
            _shoppingCart.TotalPrice = 100;
            _shoppingCart.Customer = _customer;
            _shoppingCart.Employee = _employee;

            bool result = _shoppingCartValidator.Validate(_shoppingCart);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Validate_OrdersCoutLessThanZero_ReturnsFalse()
        {
            _shoppingCart.Orders = _orders;
            _shoppingCart.TotalPrice = 100;
            _shoppingCart.Customer = _customer;
            _shoppingCart.Employee = _employee;

            bool result = _shoppingCartValidator.Validate(_shoppingCart);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_TotalPriceLessThanZero_ReturnsFalse()
        {
            _orders.Add(new Order());
            _orders.Add(new Order());
            _orders.Add(new Order());

            _shoppingCart.Orders = _orders;
            _shoppingCart.TotalPrice = 0;
            _shoppingCart.Customer = _customer;
            _shoppingCart.Employee = _employee;

            bool result = _shoppingCartValidator.Validate(_shoppingCart);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_CustomerIsNull_ReturnsFalse()
        {
            _orders.Add(new Order());
            _orders.Add(new Order());
            _orders.Add(new Order());

            _shoppingCart.Orders = _orders;
            _shoppingCart.TotalPrice = 10;
            _shoppingCart.Customer = null;
            _shoppingCart.Employee = _employee;

            bool result = _shoppingCartValidator.Validate(_shoppingCart);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_EmployeeIsNull_ReturnsFalse()
        {
            _orders.Add(new Order());
            _orders.Add(new Order());
            _orders.Add(new Order());

            _shoppingCart.Orders = _orders;
            _shoppingCart.TotalPrice = 10;
            _shoppingCart.Customer = _customer;
            _shoppingCart.Employee = null;

            bool result = _shoppingCartValidator.Validate(_shoppingCart);

            Assert.IsFalse(result);
        }
    }
}
