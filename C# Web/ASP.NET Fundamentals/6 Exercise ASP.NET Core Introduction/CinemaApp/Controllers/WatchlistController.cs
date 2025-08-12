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
            try
            {
                string? userId = this.GetUserId();

                if (userId == null)
                {
                    return this.Forbid();
                }

				IEnumerable<WatchlistViewModel> watchlist =
					await this.watchlistService.GetUserWatchlistAsync(userId);

                return this.View(watchlist);

			}
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index), "Home");
            }

            //if (!IsUserAuthenticated())
            //{
            //    //TODO: nameof(GetType(HomeController).Name i need to search for string method 
            //    return this.RedirectToAction(nameof(Index), "Home");
            //}

            //string userId = GetUserId();

            //IEnumerable<WatchlistViewModel> watchlist =
            //                    await this.watchlistService.GetUserWatchlistAsync(userId);

            //return View(watchlist);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string? movieId)
        {
            try
            {
                string? userId = this.GetUserId();
                if (userId == null)
                {
                    return this.Forbid();
                }

                bool result = await this.watchlistService.AddToWatchlistAsync(userId, movieId);

                if (result == false)
                {
                    return this.RedirectToAction(nameof(Index), "Movie");
                }

                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Remove(string? movieId) 
        {
            try
            {
                string? userId = this.GetUserId();

                if (userId == null)
                {
                    return this.Forbid();
                }

				bool result = await this.watchlistService.RemoveFromWatchlistAsync(userId, movieId);

				if (result == false)
				{
					return this.RedirectToAction(nameof(Index));
				}
                
				return this.RedirectToAction(nameof(Index), "Movie");
			}
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index), "Home");
            }
        }
    }
}
