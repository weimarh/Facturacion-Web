using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validators;

namespace TestFacturacion
{
    [TestClass]
    public class ProductValidatorTests
    {
        private readonly Product _product = new Product();
        private readonly List<string>? names = new List<string>();
        private readonly ProductValidator _validator = new ProductValidator();

        [TestMethod]
        public void CreateValidator_ValidData_ReturnsTrue()
        {
            _product.Name = "Name";
            _product.Price = 100;

            bool result = _validator.CreateValidator(_product);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CreateValidator_NameIsEmpty_ReturnsFalse()
        {
            _product.Name = "";
            _product.Price = 100;

            bool result = _validator.CreateValidator(_product);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CreateValidator_NameIsEmptyString_ReturnsFalse()
        {
            _product.Name = string.Empty;
            _product.Price = 100;

            bool result = _validator.CreateValidator(_product);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CreateValidator_PriceIsLesserThanZero_ReturnsFalse()
        {
            _product.Name = "Name";
            _product.Price = 0;

            bool result = _validator.CreateValidator(_product);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DuplicateValidator_ValidData_ReturnsFalse()
        {
            string name = "Name";
            List<string> names = new List<string>();

            names.Add(new string("John"));
            names.Add(new string("Peter"));
            names.Add(new string("Mathew"));
            names.Add(new string("Marc"));

            bool result = _validator.DuplicateValidator(name, names);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DuplicateValidator_ThereIsADuplicateName_ReturnsTrue()
        {
            string name = "Name";
            List<string> names = new List<string>();

            names.Add(new string("John"));
            names.Add(new string("Peter"));
            names.Add(new string("name"));
            names.Add(new string("Marc"));

            bool result = _validator.DuplicateValidator(name, names);

            Assert.IsTrue(result);
        }
    }
}
