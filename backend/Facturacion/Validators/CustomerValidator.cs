using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators
{
    public class CustomerValidator 
    {
        public bool Validate(Customer customer)
        {
            bool isValid = false;

            if (customer.Id > 0 && customer.Name != string.Empty && customer.Name != "")
                isValid = true;

            return isValid;
        }
    }
}
