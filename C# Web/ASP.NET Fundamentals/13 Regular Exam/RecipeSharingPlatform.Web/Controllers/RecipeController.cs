using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeSharingPlatform.Services.Core.Contracts;
using RecipeSharingPlatform.ViewModels.Recipe;

namespace RecipeSharingPlatform.Web.Controllers
{
    using static GCommon.ValidationConstants.RecipeConstants;
    public class RecipeController : BaseController
    {
        private readonly IRecipeService recipeService;
        private readonly ICategotyService categotyService;

        public RecipeController(IRecipeService recipeService, ICategotyService categotyService)
        {
            this.recipeService = recipeService;
            this.categotyService = categotyService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string? userId = this.GetUserId();

            IEnumerable<IndexRecipeViewModel>? indexViewModel = await this.recipeService.GetAllRecipesAsync(userId);

            return View(indexViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                if (this.IsAuthenticated())
                {
                    AddRecipeInputModel addRecipeInputModel = new AddRecipeInputModel();
                    addRecipeInputModel.CreatedOn = DateTime.Now.ToString(CreatedOnDateFormat);
                    addRecipeInputModel.Categories = await this.categotyService.GetAllCategories();
                    return this.View(addRecipeInputModel);
                }

                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddRecipeInputModel addRecipeInputModel)
        {
            try
            {
                if (this.ModelState.IsValid == false)
                {
                    addRecipeInputModel.Categories = await this.categotyService.GetAllCategories();
                    return this.View(addRecipeInputModel);
                }

                string userId = this.GetUserId()!;

                bool createRecipeResult = await this.recipeService.CreateRecipeAsync(userId, addRecipeInputModel);

                if (createRecipeResult == false)
                {
                    this.ModelState.AddModelError(string.Empty, "Fatal error occurred while adding a recipe!");

                    return this.View(addRecipeInputModel);
                }

                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            try
            {
                if (this.IsAuthenticated())
                {
                    string userId = this.GetUserId()!;
                    IEnumerable<FavoritesRecipesViewModel>? favoritesRecipes = await this.recipeService
                                                                                        .GetFavoritesAsync(userId);
                    return this.View(favoritesRecipes);
                }

                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                if (this.IsAuthenticated() == false)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                string userId = this.GetUserId()!;
                bool isRemoveSuccessfully = await this.recipeService.RemoveRecipeFromFavorites(userId, id);

                if (isRemoveSuccessfully == false)
                {
                    this.ModelState.AddModelError(string.Empty, "An error occurred while removing a recipe from the favorites list.");
                    return this.RedirectToAction(nameof(Favorites));
                }

                return this.RedirectToAction(nameof(Favorites));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Favorites));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(int id)
        {
            try
            {
                if (this.IsAuthenticated() == false)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                string userId = this.GetUserId()!;
                bool isSaveSuccessfully = await this.recipeService.AddRecipeToFavorites(userId, id);

                if (isSaveSuccessfully == false)
                {
                    this.ModelState.AddModelError(string.Empty, "An error occurred while adding a recipe from the favorites list.");

                    return this.RedirectToAction(nameof(Favorites));
                }

                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index));
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string? userId = this.GetUserId();
                DetailsRecipeViewModel? detailsRecipe = await this.recipeService.GetDetailsRecipeAsync(userId, id);

                if (detailsRecipe == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(detailsRecipe);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                string userId = this.GetUserId()!;
                EditRecipeInputModel? editRecipeInputModel = await this.recipeService.GetEditRecipeAsync(userId, id);

                if (editRecipeInputModel == null)
                {
                    return this.RedirectToAction(nameof(Details), new { id = id});
                }
                
                editRecipeInputModel.Categories = await this.categotyService.GetAllCategories();

                return this.View(editRecipeInputModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
                return this.RedirectToAction(nameof(Details), new {id = id});
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditRecipeInputModel inputModel)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    inputModel.Categories = await this.categotyService.GetAllCategories();
                    return this.View(inputModel);
                }

                string userId = this.GetUserId()!;
                bool isSuccessfullyEdit = await this.recipeService.EditRecipeAsync(userId, inputModel);

                if (isSuccessfullyEdit == false)
                {
                    this.ModelState.AddModelError(string.Empty, "An error occurred while editing a recipe.");
                    return this.View(inputModel);
                }

                return this.RedirectToAction(nameof(Details), new { id = inputModel.Id });

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                string userId = this.GetUserId()!;
                DeleteRecipeInputModel? deleteRecipeInputModel = await this.recipeService
                                                                        .GetDeleteRecipeAsync(userId, id);

                if (deleteRecipeInputModel == null)
                {
                    return this.RedirectToAction(nameof(Details), new { id = id });
                }

                return this.View(deleteRecipeInputModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(DeleteRecipeInputModel inputModel)
        {
            try
            {
                string userId = this.GetUserId()!;
                bool isSuccessfullySoftDelete = await this.recipeService.SoftDeleteRecipeAsync(userId, inputModel);

                if (isSuccessfullySoftDelete == false)
                {
                    this.ModelState.AddModelError(string.Empty, "An error occurred while removing a recipe.");
                    return this.RedirectToAction(nameof(Details), new { id = inputModel.Id });
                }

                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index));
            }
        }


    }
}
