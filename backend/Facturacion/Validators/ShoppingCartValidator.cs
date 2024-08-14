using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators
{
    public class ShoppingCartValidator 
    {
        public bool Validate(ShoppingCart cart)
        {
            bool isValid = false;
            
            if (cart.Orders.Count > 0 && cart.TotalPrice > 0 && cart.Customer != null && cart.Employee != null)
            {
                isValid = true;
            }
            
            return isValid;
        }
    }
}
