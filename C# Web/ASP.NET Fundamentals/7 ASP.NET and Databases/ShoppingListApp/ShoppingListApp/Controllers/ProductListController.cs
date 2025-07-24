using Microsoft.AspNetCore.Mvc;


using ShoppingListApp.Services.Core.Interfaces;
using ShoppingListApp.Web.ViewModels.Product;
using ShoppingListApp.Web.ViewModels.ProductList;

namespace ShoppingListApp.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IProductListService productListService;
        public ProductListController(IProductListService productListService)
        {
            this.productListService = productListService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<AllProductListsIndexViewModel> allProductLists = 
                                            await this.productListService.GetAllProductListsAsync();

            return View(allProductLists);
        }

        [HttpGet]
        public async Task<IActionResult> GetSingle(int id)
        {
            SingleProductListViewModel singleProductListViewModel =
                            await this.productListService.GetSingleProductList(id);

            return View(singleProductListViewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add( CreateProductListViewModel createProductListViewModel)
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction(nameof(Index));
            }

            await this.productListService.CreatePorductListAsync(createProductListViewModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AddProduct(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct( CreateProductViewModel createProductViewModel, int id)
        {
            Console.WriteLine(id);
            await this.productListService.AddProductToListAsync(createProductViewModel, id);

            return RedirectToAction(nameof(GetSingle), new {id = id});
        }
    }
}
