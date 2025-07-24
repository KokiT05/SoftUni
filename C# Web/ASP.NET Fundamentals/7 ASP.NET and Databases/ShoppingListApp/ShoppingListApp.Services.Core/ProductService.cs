using ShoppingListApp.Data;
using ShoppingListApp.Data.Models;
using ShoppingListApp.Services.Core.Interfaces;
using ShoppingListApp.Web.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Services.Core
{
    public class ProductService : IProductService
    {
        private readonly ShoppingListDbContext databaseContext;

        public ProductService(ShoppingListDbContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<Product> AddProductAsync(CreateProductViewModel createProductViewModel, int productListId)
        {
            Product product = new Product()
            {
                Name = createProductViewModel.Name,
                Description = createProductViewModel.Description,
                Price = createProductViewModel.Price,
                ProductListId = productListId
            };

            await this.databaseContext.AddAsync(product);
            await this.databaseContext.SaveChangesAsync();

            return product;
        }
    }
}
