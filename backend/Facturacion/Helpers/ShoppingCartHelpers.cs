using DTOs;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class ShoppingCartHelpers
    {
        public static decimal CalculateTotalPrice(List<Order> orders)
        {
            decimal totalPrice = 0;

            foreach (var order in orders)
            {
                if (order.Quantity <= 0 || order.Product.Price <= 0)
                    throw new Exception("Price and/or quantity must be greater than zero");

                totalPrice += order.Quantity * order.Product.Price;
            }

            return totalPrice;
        }
    }
}
