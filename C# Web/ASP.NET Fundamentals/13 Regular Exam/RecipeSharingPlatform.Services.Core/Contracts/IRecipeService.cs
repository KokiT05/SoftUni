using RecipeSharingPlatform.ViewModels.Recipe;

namespace RecipeSharingPlatform.Services.Core.Contracts
{
    public interface IRecipeService
    {
        Task<IEnumerable<IndexRecipeViewModel>?> GetAllRecipesAsync(string? userId);

        Task<bool> CreateRecipeAsync(string userId, AddRecipeInputModel addRecipeInputModel);

        Task<IEnumerable<FavoritesRecipesViewModel>?> GetFavoritesAsync(string userId);

        Task<bool> RemoveRecipeFromFavorites(string userId, int recipeId);

        Task<bool> AddRecipeToFavorites(string userId, int recipeId);

        Task<DetailsRecipeViewModel?> GetDetailsRecipeAsync(string? userId, int recipeId);

        Task<EditRecipeInputModel?> GetEditRecipeAsync(string userId, int recipeId);

        Task<bool> EditRecipeAsync(string userId, EditRecipeInputModel inputModel);

        Task<DeleteRecipeInputModel?> GetDeleteRecipeAsync(string userId, int recipeId);

        Task<bool> SoftDeleteRecipeAsync(string userId, DeleteRecipeInputModel inputModel);
    }
}
