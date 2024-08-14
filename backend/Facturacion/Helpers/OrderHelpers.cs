using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class OrderHelpers
    {
        public static decimal CalculatePartialPrice(int quantity, decimal price)
        {
            if (quantity <= 0 || price <= 0)
                throw new ArgumentException("Price and/or quantity must be greater than zero");

            return quantity * price;
        }
    }
}
