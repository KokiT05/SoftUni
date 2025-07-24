

using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Data;
using ShoppingListApp.Data.Models;
using ShoppingListApp.Services.Core.Interfaces;
using ShoppingListApp.Web.ViewModels.Product;
using ShoppingListApp.Web.ViewModels.ProductList;

namespace ShoppingListApp.Services.Core
{
    public class ProductListService : IProductListService
    {
        private readonly ShoppingListDbContext databaseContext;
        private readonly IProductService productService;
        public ProductListService(ShoppingListDbContext databaseContext, IProductService productService)
        {
            this.databaseContext = databaseContext;
            this.productService = productService;
        }

        public async Task AddProductToListAsync(CreateProductViewModel createProductViewModel, int productListId)
        {
            Product product = await this.productService.AddProductAsync(createProductViewModel, productListId);

            ProductList productList = await this.databaseContext.ProductLists
                                                                .Where(pl => pl.Id == productListId)
                                                                .FirstAsync();

            productList.Products.Add(product);
            productList.TotalPrice += product.Price;

            await this.databaseContext.SaveChangesAsync();
        }

        public async Task CreatePorductListAsync(CreateProductListViewModel createProductListViewModel)
        {
            ProductList productList = new ProductList()
            {
                Name = createProductListViewModel.Name,
                Description = createProductListViewModel.Description,
            };

            await this.databaseContext.AddAsync(productList);
            await this.databaseContext.SaveChangesAsync();
        }

        public async Task<List<AllProductListsIndexViewModel>> GetAllProductListsAsync()
        {
            List<AllProductListsIndexViewModel> allProductLists = await this.databaseContext.ProductLists
                                        .AsNoTracking()
                                        .Select(pl => new AllProductListsIndexViewModel()
                                        {
                                            Id = pl.Id,
                                            Name = pl.Name,
                                            Description = pl.Description,
                                            TotalPrice = pl.TotalPrice,
                                        })
                                        .ToListAsync();

            return allProductLists;
        }

        public async Task<SingleProductListViewModel> GetSingleProductList(int id)
        {
            List<ProductViewModel> products =
                                    await this.databaseContext.Products
                                    .AsNoTracking()
                                    .Where(p => p.ProductListId == id)
                                    .Select(p => new ProductViewModel()
                                    {
                                        Id = p.Id,
                                        Name = p.Name,
                                        Description = p.Description,
                                        Price = p.Price,
                                    })
                                    .ToListAsync();

            SingleProductListViewModel singleProductListViewModel =
                            await this.databaseContext.ProductLists
                            .AsNoTracking()
                            .Where(pl => pl.Id == id)
                            .Select(pl => new SingleProductListViewModel()
                            {
                                Id = pl.Id,
                                Name = pl.Name,
                                Description = pl.Description,
                                TotalPrice = pl.TotalPrice,
                                Products = products
                            })
                            .FirstAsync();

            
            return singleProductListViewModel;
        }
    }
}
