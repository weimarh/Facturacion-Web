using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public record class ShoppingCartDTO(int customerId, string? customerComplement, string? customerName, List<string>? ProductsNames,
    List<decimal>? UnitPrice, List<int>? Quantity, decimal TotalPrice, DateTime? SellDate, string? EmployeeName);

    public record class CreateShoppingCartDTO(List<Order> orders, int customerId, int employeeId);
}
