using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Data.Models
{
    public class ProductList
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal TotalPrice { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
