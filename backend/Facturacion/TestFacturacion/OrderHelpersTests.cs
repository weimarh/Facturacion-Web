using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFacturacion
{
    [TestClass]
    public class OrderHelpersTests
    {
        [TestMethod]
        public void CalculatePartialPrice_ValidData_ReturnsTrue()
        {
            //Arrange
            int quantity = 1;
            decimal price = 1.50m;
            decimal expected = ((decimal)quantity * price);

            //Actual

            decimal actual = OrderHelpers.CalculatePartialPrice(1, 1.50m);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePartialPrice_QuantityLesserThanZero_ThrowsException()
        {
            //Arrange
            int quantity = -1;
            decimal price = 1.50m;
            Exception? ExpectedException = null;

            //Actual
            try
            {
                decimal actual = OrderHelpers.CalculatePartialPrice(quantity, price);
            }
            catch (Exception ex)
            {
                ExpectedException = ex;
            }

            //Assert
            Assert.IsNotNull(ExpectedException);
        }

        [TestMethod]
        public void CalculatePartialPrice_PriceLesserThanZero_ThrowsException()
        {
            //Arrange
            int quantity = 1;
            decimal price = -1.50m;
            Exception? ExpectedException = null;

            //Actual
            try
            {
                decimal actual = OrderHelpers.CalculatePartialPrice(quantity, price);
            }
            catch (Exception ex)
            {
                ExpectedException = ex;
            }

            //Assert
            Assert.IsNotNull(ExpectedException);
        }
    }
}
