using Helpers;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFacturacion
{
    [TestClass]
    public class ShoppingCartHelpersTests
    {
        private readonly List<Order> _orders = new List<Order>();

        [TestMethod]
        public void CalculateTotalPrice_ValidData_ReturnsVaild()
        {
            Product product1 = new Product()
            {
                Price = 100.5m
            };

            Product product2 = new Product()
            {
                Price = 10.5m
            };

            _orders.Add(new Order
            {
                Id = 1,
                Quantity = 4,
                Product = product1
            });

            _orders.Add(new Order
            {
                Id = 2,
                Quantity = 1,
                Product = product2
            });

            decimal result = ShoppingCartHelpers.CalculateTotalPrice(_orders);

            Assert.AreEqual(412.5m, result);
        }

        [TestMethod]
        public void CalculateTotalPrice_QuantityIsZero_ReturnsVaild()
        {
            Exception? ExpectedException = null;

            Product product1 = new Product()
            {
                Price = 100.5m
            };

            Product product2 = new Product()
            {
                Price = 10.5m
            };

            _orders.Add(new Order
            {
                Id = 1,
                Quantity = 4,
                Product = product1
            });

            _orders.Add(new Order
            {
                Id = 2,
                Quantity = 0,
                Product = product2
            });

            try
            {
                decimal result = ShoppingCartHelpers.CalculateTotalPrice(_orders);
            }
            catch (Exception ex)
            {
                ExpectedException = ex;
            }

            Assert.IsNotNull(ExpectedException);
        }

        [TestMethod]
        public void CalculateTotalPrice_PriceIsZero_ReturnsVaild()
        {
            Exception? ExpectedException = null;

            Product product1 = new Product()
            {
                Price = 100.5m
            };

            Product product2 = new Product()
            {
                Price = 0
            };

            _orders.Add(new Order
            {
                Id = 1,
                Quantity = 4,
                Product = product1
            });

            _orders.Add(new Order
            {
                Id = 2,
                Quantity = 10,
                Product = product2
            });

            try
            {
                decimal result = ShoppingCartHelpers.CalculateTotalPrice(_orders);
            }
            catch (Exception ex)
            {
                ExpectedException = ex;
            }

            Assert.IsNotNull(ExpectedException);
        }
    }
}
