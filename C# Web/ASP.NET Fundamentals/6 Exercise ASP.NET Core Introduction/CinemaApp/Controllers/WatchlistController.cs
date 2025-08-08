using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Watchlist;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Controllers
{
    public class WatchlistController : BaseController
    {
        private readonly IWatchlistService watchlistService;

        public WatchlistController(IWatchlistService watchlistService)
        {
            this.watchlistService = watchlistService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!IsUserAuthenticated())
            {
                //TODO: nameof(GetType(HomeController).Name i need to search for string method 
                return this.RedirectToAction(nameof(Index), "Home");
            }

            string userId = GetUserId();

            IEnumerable<WatchlistViewModel> watchlist =
                                await this.watchlistService.GetUserWatchlistAsync(userId);

            return View(watchlist);
        }

        public async Task<IActionResult> Add(string movieId)
        {
            if (!IsUserAuthenticated())
            {
				return this.RedirectToAction(nameof(Index), "Home");
			}

            string userId = GetUserId();

            bool isInWatchlist = 
                await this.watchlistService.IsMovieInWatchlistAsync(userId, Guid.Parse(movieId);

            if (!isInWatchlist)
            {
                await this.watchlistService.AddToWatchlistAsync(userId, movieId);
            }

            return this.RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Remove(string movieId) 
        {
            if (!IsUserAuthenticated())
            {
				return this.RedirectToAction(nameof(Index), "Home");
			}

            string userId = GetUserId();

            Guid movieGuidId = Guid.Parse(movieId);

			// TODO: IsMovieInWatchlistAsync(userId, movieGuidId).Result;
			bool isInWatchlist =
	                await this.watchlistService.IsMovieInWatchlistAsync(userId, movieGuidId);

            if (isInWatchlist)
            {
                await this.watchlistService.RemoveFromWatchlistAsync(userId, movieId);
            }

			return this.RedirectToAction(nameof(Index));
        }
    }
}
