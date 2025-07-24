using ShoppingListApp.Web.ViewModels.Product;
using ShoppingListApp.Web.ViewModels.ProductList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Services.Core.Interfaces
{
    public interface IProductListService
    {
        Task<List<AllProductListsIndexViewModel>> GetAllProductListsAsync();

        Task<SingleProductListViewModel> GetSingleProductList(int id);

        Task CreatePorductListAsync(CreateProductListViewModel createProductListViewModel);

        Task AddProductToListAsync(CreateProductViewModel createProductViewModel, int productListId);
    }
}
