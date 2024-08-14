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
    public class OrderValidatorTests
    {
        Order order = new Order();
        Product product = new Product();
        ShoppingCart shoppingCart = new ShoppingCart();
        OrderValidator validator = new OrderValidator();

        [TestMethod]
        public void CreateValidator_ValidData_ReturnsTrue()
        {
            order .Id = 1;
            order.ProductId = 1;
            order.Product = product;
            order.Quantity = 1;
            order.PartialPrice = 100;
            order.ShoppingCartId = 1;
            order.ShoppingCart = shoppingCart;

            bool result = validator.CreateValidator(order);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CreateValidator_ProductIdLessThanZero_ReturnsTrue()
        {
            order.Id = 1;
            order.ProductId = -1;
            order.Product = product;
            order.Quantity = 1;
            order.PartialPrice = 100;
            order.ShoppingCartId = 1;
            order.ShoppingCart = shoppingCart;

            bool result = validator.CreateValidator(order);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CreateValidator_ProductIsNull_ReturnsTrue()
        {
            order.Id = 1;
            order.ProductId = 1;
            order.Product = null;
            order.Quantity = 1;
            order.PartialPrice = 100;
            order.ShoppingCartId = 1;
            order.ShoppingCart = shoppingCart;

            bool result = validator.CreateValidator(order);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CreateValidator_QuantityLessThanZero_ReturnsTrue()
        {
            order.Id = 1;
            order.ProductId = 1;
            order.Product = product;
            order.Quantity = 0;
            order.PartialPrice = 100;
            order.ShoppingCartId = 1;
            order.ShoppingCart = shoppingCart;

            bool result = validator.CreateValidator(order);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CreateValidator_ShoppingCartIdLessThanZero_ReturnsTrue()
        {
            order.Id = 1;
            order.ProductId = 1;
            order.Product = product;
            order.Quantity = 1;
            order.PartialPrice = 100;
            order.ShoppingCartId = -1;
            order.ShoppingCart = shoppingCart;

            bool result = validator.CreateValidator(order);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CreateValidator_ShoppingCartIsNull_ReturnsTrue()
        {
            order.Id = 1;
            order.ProductId = 1;
            order.Product = product;
            order.Quantity = 1;
            order.PartialPrice = 100;
            order.ShoppingCartId = 1;
            order.ShoppingCart = null;

            bool result = validator.CreateValidator(order);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateValidator_ValidData_ReturnsTrue()
        {
            order.Id = 1;
            order.ProductId = 1;
            order.Product = product;
            order.Quantity = 1;
            order.PartialPrice = 100;
            order.ShoppingCartId = 1;
            order.ShoppingCart = shoppingCart;

            bool result = validator.UpdateValidator(order);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdateValidator_ProductIdLessThanZero_ReturnsTrue()
        {
            order.Id = 1;
            order.ProductId = -1;
            order.Product = product;
            order.Quantity = 1;
            order.PartialPrice = 100;
            order.ShoppingCartId = 1;
            order.ShoppingCart = shoppingCart;

            bool result = validator.UpdateValidator(order);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateValidator_ProductIsNull_ReturnsTrue()
        {
            order.Id = 1;
            order.ProductId = 1;
            order.Product = null;
            order.Quantity = 1;
            order.PartialPrice = 100;
            order.ShoppingCartId = 1;
            order.ShoppingCart = shoppingCart;

            bool result = validator.UpdateValidator(order);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateValidator_QuantityLessThanZero_ReturnsTrue()
        {
            order.Id = 1;
            order.ProductId = 1;
            order.Product = product;
            order.Quantity = 0;
            order.PartialPrice = 100;
            order.ShoppingCartId = 1;
            order.ShoppingCart = shoppingCart;

            bool result = validator.UpdateValidator(order);

            Assert.IsFalse(result);
        }

      
    }
}
