using Horizons.Web.ViewModels.Destination;

namespace Horizons.Services.Core.Contracts
{
    public interface IDestinationService
    {
        Task<IEnumerable<IndexDestinationViewModel>> GetAllDestination(string? userId);

        Task CreateDestination(AddDestinationViewModel inputAddDestinationModel, string? userId);

        Task<DetailsDestinationViewModel?> GetDetailsDestination(int? destinationId, string? userId);

        Task<EditDestinationViewModel?> GetEditDestination(int? destinationId, string? userId);

        Task<bool> EditDestinationAsync(EditDestinationViewModel editDestinationViewModel, string? userId);

        Task<DeleteDestinationViewModel?> GetDeleteDestination(int? destinationId);

        Task<bool> DeleteDestination(DeleteDestinationViewModel? inputDeleteDestinationModel, string? userId);

        Task<IEnumerable<FavoritesDestinationViewModel>?> GetAllFavoritesDestinations(string? userId);

        Task AddDestinationToFavorites(int destinationId, string? userId);

        Task RemoveDestinationFromFavorite(int? destinationId, string? userId);
    }
}
