using ShoppingListApp.Data.Models;
using ShoppingListApp.Web.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Services.Core.Interfaces
{
    public interface IProductService
    {
        Task<Product> AddProductAsync(CreateProductViewModel createProductViewModel, int productListId);
    }
}
