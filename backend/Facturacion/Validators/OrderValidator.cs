using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators
{
    public class OrderValidator
    {
        public bool CreateValidator(Order order)
        {
            bool isValid = false;

            if(order.ProductId > 0 && order.Product != null && order.Quantity > 0 && order.ShoppingCartId > 0 && order.ShoppingCart != null)
            {
                isValid = true;
            }

            return isValid;
        }

        public bool UpdateValidator(Order order)
        {
            bool isValid = false;

            if (order.ProductId > 0 && order.Product != null && order.Quantity > 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
