using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer : IPerson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int Id { get; set; }
        public string? Complement {  get; set; } = string.Empty;
        [Required]
        [StringLength(60)]
        public string? Name { get; set; } = "None";
        public string? Email { get; set; } = string.Empty;
        public virtual List<ShoppingCart>? ShoppingCarts { get; set;}
    }
}
