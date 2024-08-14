using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Employee : IPerson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int Id { get; set; }
        public string? Complement { get; set; } = string.Empty;
        [Required]
        [StringLength(60)]
        public string? Name { get; set; }
        public Rol Rol { get; set; }
        public virtual List<ShoppingCart>? ShoppingCarts { get; set; }
    }
}
