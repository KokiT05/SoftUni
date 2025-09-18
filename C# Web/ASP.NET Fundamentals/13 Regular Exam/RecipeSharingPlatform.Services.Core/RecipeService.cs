using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeSharingPlatform.Data;
using RecipeSharingPlatform.Data.Models;
using RecipeSharingPlatform.Services.Core.Contracts;
using RecipeSharingPlatform.ViewModels.Recipe;
using System.Globalization;

namespace RecipeSharingPlatform.Services.Core
{
    using static GCommon.ValidationConstants.RecipeConstants;
    public class RecipeService : IRecipeService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<IdentityUser> userManager;

        public RecipeService(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<IndexRecipeViewModel>?> GetAllRecipesAsync(string? userId)
        {
            IEnumerable<IndexRecipeViewModel> recipes = await this.dbContext
                                                                    .Recipes
                                                                    .Include(r => r.Category)
                                                                    .Include(r => r.UsersRecipes)
                                                                    .AsNoTracking()
                                                                    .Select(r => new IndexRecipeViewModel()
                                                                    {
                                                                        Id = r.Id,
                                                                        Title = r.Title,
                                                                        ImageUrl = r.ImageUrl,
                                                                        Category = r.Category.Name,
                                                                        SavedCount = r.UsersRecipes.Count,
                                                                        IsAuthor = userId == null ? false :
                                                                        r.AuthorId.ToLower() == userId.ToLower(),
                                                                        IsSaved = userId == null ? false :
                                                                        r.UsersRecipes.Any
                                                                        (ur => ur.UserId.ToLower() == userId.ToLower())
                                                                    }).ToListAsync();

            return recipes;
        }


        public async Task<bool> CreateRecipeAsync(string userId, AddRecipeInputModel addRecipeInputModel)
        {
            bool result = false;

            
            bool isCreatedOnValidDate = DateTime.TryParseExact(addRecipeInputModel.CreatedOn,
                                                                CreatedOnDateFormat,
                                                                CultureInfo.InvariantCulture,
                                                                DateTimeStyles.None,
                                                                out DateTime validDateTime);

            if ((await this.IsUserExist(userId)) && 
                (await this.IsCategoryExist(addRecipeInputModel.CategoryId)) && 
                isCreatedOnValidDate)
            {
                Recipe recipe = new Recipe()
                {
                    Title = addRecipeInputModel.Title,
                    Instructions = addRecipeInputModel.Instructions,
                    CategoryId = addRecipeInputModel.CategoryId,
                    AuthorId = userId,
                    CreatedOn = validDateTime,
                    ImageUrl = addRecipeInputModel.ImageUrl
                };

                await this.dbContext.Recipes.AddAsync(recipe);
                await this.dbContext.SaveChangesAsync();

                result = true;
            }

            return result;
        }

        public async Task<IEnumerable<FavoritesRecipesViewModel>?> GetFavoritesAsync(string userId)
        {
            IEnumerable<FavoritesRecipesViewModel>? favoritesRecipes = null;

            if (await this.IsUserExist(userId))
            {
                favoritesRecipes = await this.dbContext.UsersRecipes
                                                        .Include(ur => ur.Recipe)
                                                        .Include(ur => ur.Recipe.Category)
                                                        .AsNoTracking()
                                                        .Where(ur => ur.UserId == userId)
                                                        .Select(ur => new FavoritesRecipesViewModel()
                                                        {
                                                            Id = ur.Recipe.Id,
                                                            Title = ur.Recipe.Title,
                                                            ImageUrl = ur.Recipe.ImageUrl,
                                                            Category = ur.Recipe.Category.Name,

                                                        })
                                                        .ToListAsync();
            }

            return favoritesRecipes;
        }

        public async Task<bool> RemoveRecipeFromFavorites(string userId, int recipeId)
        {
            bool result = false;

            Recipe? recipe = await this.dbContext.Recipes.FindAsync(recipeId);

            if ((await this.IsUserExist(userId)) && (recipe != null))
            {
                UserRecipe? userRecipe = await this.dbContext.UsersRecipes.FindAsync([userId, recipeId]);

                if (userRecipe != null)
                {
                    this.dbContext.UsersRecipes.Remove(userRecipe);
                    await this.dbContext.SaveChangesAsync();

                    result = true;
                }
            }

            return result;
        }

        public async Task<bool> AddRecipeToFavorites(string userId, int recipeId)
        {
            bool result = false;

            Recipe? recipe = await this.dbContext.Recipes.FindAsync(recipeId);

            if ((await this.IsUserExist(userId)) && (recipe != null) && (recipe.AuthorId.ToLower() != userId.ToLower()))
            {
                UserRecipe? userRecipe = await this.dbContext.UsersRecipes.FindAsync([userId, recipeId]);

                if (userRecipe == null)
                {
                    userRecipe = new UserRecipe()
                    {
                        UserId = userId,
                        RecipeId = recipeId
                    };

                    result = true;
                    await this.dbContext.UsersRecipes.AddAsync(userRecipe);
                    await this.dbContext.SaveChangesAsync();
                }
            }

            return result;
        }

        public async Task<DetailsRecipeViewModel?> GetDetailsRecipeAsync(string? userId, int recipeId)
        {
            DetailsRecipeViewModel? detailsRecipe = null;

            Recipe? recipe = await this.dbContext.Recipes.Include(r => r.Author)
                                                        .Include(r => r.Category)
                                                        .Include(r => r.UsersRecipes)
                                                        .AsNoTracking()
                                                        .FirstAsync(r => r.Id == recipeId);

            if ((recipe != null))
            {
                detailsRecipe = new DetailsRecipeViewModel()
                {
                    Id = recipe.Id,
                    Title = recipe.Title,
                    Instructions = recipe.Instructions,
                    ImageUrl = recipe.ImageUrl,
                    CreatedOn = recipe.CreatedOn,
                    Author = recipe.Author.NormalizedUserName!,
                    Category = recipe.Category.Name,
                    IsAuthor = userId != null ? userId.ToLower() == recipe.AuthorId.ToLower() : false,
                    IsSaved = userId != null ? recipe.UsersRecipes.Any(ur => ur.UserId.ToLower() == userId.ToLower() 
                                                                    && ur.RecipeId == recipe.Id) : false
                };
            }

            return detailsRecipe;
        }

        public async Task<EditRecipeInputModel?> GetEditRecipeAsync(string userId, int recipeId)
        {
            EditRecipeInputModel? getEditRecipeInputModell = null;
            
            
            Recipe? recipe = await this.dbContext.Recipes.FindAsync(recipeId);

            if ((await this.IsUserExist(userId)) && (recipe != null))
            {
                getEditRecipeInputModell = new EditRecipeInputModel()
                {
                    Id = recipe.Id,
                    Title = recipe.Title,
                    Instructions = recipe.Instructions,
                    ImageUrl = recipe.ImageUrl,
                    CreatedOn = recipe.CreatedOn,
                    CategoryId = recipe.CategoryId
                };
            }

            return getEditRecipeInputModell;
        }

        public async Task<bool> EditRecipeAsync(string userId, EditRecipeInputModel inputModel)
        {
            bool result = false;

            if ((await this.IsUserExist(userId)) && (await this.IsCategoryExist(inputModel.CategoryId)))
            {
                Recipe recipe = (await this.dbContext.Recipes.FindAsync(inputModel.Id))!;

                if (userId.ToLower() == recipe.AuthorId.ToLower())
                {
                    recipe.Title = inputModel.Title;
                    recipe.Instructions = inputModel.Instructions;
                    recipe.ImageUrl = inputModel.ImageUrl;
                    recipe.CreatedOn = inputModel.CreatedOn;
                    recipe.CategoryId = inputModel.CategoryId;

                    result = true;

                    await this.dbContext.SaveChangesAsync();
                }
            }

            return result;
        }

        public async Task<DeleteRecipeInputModel?> GetDeleteRecipeAsync(string userId, int recipeId)
        {
            DeleteRecipeInputModel? deleteRecipeInputModel = null;

            IdentityUser? user = await this.userManager.FindByIdAsync(userId);
            Recipe? recipe = await this.dbContext.Recipes.FindAsync(recipeId);

            if ((user != null) && (recipe != null) && (userId.ToLower() == recipe.AuthorId.ToLower()))
            {
                deleteRecipeInputModel = new DeleteRecipeInputModel()
                {
                    Id = recipe.Id,
                    Title = recipe.Title,
                    AuthorId = recipe.AuthorId,
                    Author = user.NormalizedUserName!
                };
            }

            return deleteRecipeInputModel;
        }

        public async Task<bool> SoftDeleteRecipeAsync(string userId, DeleteRecipeInputModel inputModel)
        {
            bool result = false;

            if ((await this.IsUserExist(userId)) && (userId.ToLower() == inputModel.AuthorId.ToLower()))
            {
                Recipe recipe = (await this.dbContext.Recipes.FindAsync(inputModel.Id))!;

                recipe.IsDeleted = true;

                await this.dbContext.SaveChangesAsync();

                result = true;
            }

            return result;
        }

        private async Task<bool> IsUserExist(string userId)
        {
            bool result = false;

            IdentityUser? user = await this.userManager.FindByIdAsync(userId);

            if (user != null)
            {
                result = true;
            }

            return result;
        }

        private async Task<bool> IsCategoryExist(int categoryId)
        {
            bool result = false;

            Category? category = await this.dbContext.Categories.FindAsync(categoryId);
            if (category != null)
            {
                result = true;
            }

            return result;
        }
    }
}
