using Horizons.Web.ViewModels.Destination;

namespace Horizons.Services.Core.Contracts
{
    public interface IDestinationService
    {
        Task<IEnumerable<IndexDestinationViewModel>> GetAllDestinationAsync(string? userId);

        Task<bool> CreateDestination(AddDestinationInputModel inputAddDestinationModel, string userId);

        Task<DetailsDestinationViewModel?> GetDetailsDestinationAsync(int? destinationId, string? userId);

        Task<EditDestinationInputModel?> GetEditDestinationAsync(int? destinationId, string userId);

        Task<bool> EditDestinationAsync(EditDestinationInputModel editDestinationInputModell, string userId);

        Task<DeleteDestinationInputModel?> GetDeleteDestinationAsync(int? destinationId, string userId);

        Task<bool> SoftDeleteDestinationAsync(DeleteDestinationInputModel inputDeleteDestinationModel, string userId);

        Task<IEnumerable<FavoritesDestinationViewModel>?> GetUserFavoritesDestinationsAsync(string userId);

        Task<bool> AddDestinationToFavoritesAsync(int destinationId, string userId);

        Task<bool> RemoveDestinationFromFavorite(int destinationId, string userId);
    }
}
