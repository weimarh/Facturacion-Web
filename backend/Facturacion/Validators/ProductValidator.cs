using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators
{
    public class ProductValidator
    {
        public bool CreateValidator(Product product)
        {
            bool isValid = false;

            if(product.Name != null && product.Name != "" && product.Price > 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public bool UpdateValidator(Product product)
        {
            bool isValid = false;

            if (product.Name != null && product.Name != "" && product.Price > 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public bool DuplicateValidator(string? productName, List<string>? names)
        {
            bool isDuplicate = false;

            foreach (string name in names)
            {
                if (name.ToLower() == productName.ToLower())
                    isDuplicate = true;
            }

            return isDuplicate;
        }
    }
}
