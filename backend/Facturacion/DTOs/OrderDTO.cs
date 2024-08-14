using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public record class OrderDTO([Required] string? ProductName, [Required] int Quantity, [Required] decimal TotalPrice);
    public record class CreateOrderDTO([Required] int ProductId, [Required] int Quantity, [Required] int ShoppingCartId);
}
