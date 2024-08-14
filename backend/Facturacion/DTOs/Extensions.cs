using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public static class Extensions
    {
        public static ProductDTO AsDto(this Product product) => new ProductDTO(product.Name, product.Description, product.Category.ToString(), product.Price);
        public static CustomerDTO AsDto(this Customer customer) => new CustomerDTO(customer.Id, customer.Complement, customer.Name, customer.Email);
        public static OrderDTO AsDto(this Order order) => new OrderDTO(order.Product?.Name, order.Quantity,
            order.PartialPrice);
        public static EmployeeDTO AsDto(this Employee employee) => new(employee.Id, employee.Complement, employee.Name, employee.Rol.ToString()); //Nueva forma de crear un nuevo objeto
        public static ShoppingCartDTO AsDto(this ShoppingCart shoppingCart)
        {
            List<string> products = new List<string>();
            List<decimal> prices = new List<decimal>();
            List<int> quantities = new List<int>();
            decimal total = 0;
            foreach (var item in shoppingCart.Orders)
            {
                products.Add(item.Product.Name);
                prices.Add(item.Product.Price);
                quantities.Add(item.Quantity);
                total += item.Product.Price * item.Quantity;
            }

            return new ShoppingCartDTO(shoppingCart.CustomerId, shoppingCart.Customer.Complement, shoppingCart.Customer.Name, products, prices, quantities, total, shoppingCart.SellDate, shoppingCart.Employee.Name);
        }


    }
}
