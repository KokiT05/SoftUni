using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Identity.Client;

namespace CinemaApp.Web.Controllers
{
	using static ViewModels.ValidationMessages.Movie;
	public class MovieController : BaseController
    {
		private readonly IMovieService movieService;
		private readonly IWatchlistService watchlistService;

		public MovieController(IMovieService movieService, IWatchlistService watchlistService)
		{
			this.movieService = movieService;
			this.watchlistService = watchlistService;
		}

		[HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
		{
			IEnumerable<AllMoviesIndexViewModel> movies = await this.movieService.GetAllMoviesAsync();

			if (this.IsUserAuthenticated())
			{
				foreach (AllMoviesIndexViewModel movieViewModel in movies)
				{
					movieViewModel.IsAddedToUserWatchlist = await this.watchlistService
																	.IsMovieInWatchlistAsync(this.GetUserId(), movieViewModel.Id);
				}
			}

			return View(movies);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(MovieFormViewModel inputModel)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(inputModel);
			}

			try
			{
				await this.movieService.AddAsync(inputModel);

				return this.RedirectToAction(nameof(Index));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);

				this.ModelState.AddModelError(string.Empty, ServiceCreateError);
				return this.View(inputModel);
			}
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Details(string? id)
		{
			try
			{
				MovieDetailsViewModel? movieDetailsViewModel =
													await this.movieService.GetMovieDetailsByIdAsync(id);

				if (movieDetailsViewModel == null)
				{
					// TODO: Custom 404 page
					return this.RedirectToAction(nameof(Index));
				}

				return this.View(movieDetailsViewModel);
			}
			catch (Exception e)
			{
				// TODO: Implement it with th ILogger
				// TODO: Add Js barsto indicate such errors
				Console.WriteLine(e.Message);

				return this.RedirectToAction(nameof(Index));
			}
		}

		[HttpGet]
		public async Task<IActionResult> Edit(string? id)
		{
			try
			{
				MovieFormViewModel? editableMovie =
								await this.movieService.GetEditableMovieByIdAsync(id);

				if (editableMovie == null)
				{
					return this.RedirectToAction(nameof(Index));
				}

				return this.View(editableMovie);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);

				return this.RedirectToAction(nameof(Index));
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(MovieFormViewModel inputEditModel)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(inputEditModel);
			}

			try
			{
				bool result = await this.movieService.EditMovieAsync(inputEditModel);

				if (!result)
				{
					// TODO: Custom 404 page
					return this.RedirectToAction(nameof(Index));
				}

				return this.RedirectToAction(nameof(Details), new { id = inputEditModel.Id });
			}
			catch (Exception e)
			{
				// TODO: Implement it with the ILogger
				// TODO: Add JS bars to indicate such errors
				Console.WriteLine(e.Message);

				return this.RedirectToAction(nameof(Index));
			}
		}

		[HttpGet]
		public async Task<IActionResult> Delete(string? id)
		{
			try
			{
                DeleteMovieViewModel? movieToBeDeleted = 
											await this.movieService.GetMovieDeleteDetailsByIdAsync(id);

                if (movieToBeDeleted == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

				return this.View(movieToBeDeleted);
            }
			catch (Exception e)
			{
                Console.WriteLine(e.Message);

				return this.RedirectToAction(nameof(Index));   
			}
		}

		[HttpPost]
		public async Task<IActionResult> Delete(DeleteMovieViewModel inputModel)
		{

			try
			{
				if (!this.ModelState.IsValid)
				{
					return this.RedirectToAction(nameof(Index));
				}

				bool deleteResult = await this.movieService.SoftDeleteAsync(inputModel.Id);

				if (deleteResult == false)
				{
					return this.RedirectToAction(nameof(Index));
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

