using CinemaApp.Web.ViewModels.Movie;

namespace CinemaApp.Services.Core.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<AllMoviesIndexViewModel>> GetAllMoviesAsync();

        Task AddAsync(MovieFormViewModel model);

        Task<MovieDetailsViewModel?> GetMovieDetailsByIdAsync(string? id);

        Task<MovieFormViewModel?> GetEditableMovieByIdAsync(string? id);
        Task<bool> EditMovieAsync(MovieFormViewModel model);

        Task<bool> SoftDeleteAsync(string? id);

        Task<bool> HardDeleteAsync(string? id);
    }
}
