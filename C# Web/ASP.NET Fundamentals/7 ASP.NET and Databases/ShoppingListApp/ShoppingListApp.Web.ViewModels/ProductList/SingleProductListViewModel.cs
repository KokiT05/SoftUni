using ShoppingListApp.Web.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Web.ViewModels.ProductList
{
    public class SingleProductListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal? TotalPrice { get; set; }

        public List<ProductViewModel>? Products { get; set; } = new List<ProductViewModel>();
    }
}
