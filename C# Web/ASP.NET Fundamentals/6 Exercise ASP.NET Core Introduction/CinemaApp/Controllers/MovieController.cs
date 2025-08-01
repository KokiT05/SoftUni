using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Identity.Client;

namespace CinemaApp.Web.Controllers
{
	using static ViewModels.ValidationMessages.Movie;
	public class MovieController : Controller
	{
		private readonly IMovieService movieService;

		public MovieController(IMovieService movieService)
		{
			this.movieService = movieService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			IEnumerable<AllMoviesIndexViewModel> movies = await this.movieService.GetAllMoviesAsync();

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
			MovieDetailsViewModel? movie = await this.movieService.GetMovieDetailsByIdAsync(id);

			if (movie == null)
			{
				return this.RedirectToAction(nameof(Index));
			}

			return this.View(movie);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(string? id)
		{
            MovieDetailsViewModel? movie = await this.movieService.GetMovieDetailsByIdAsync(id);

            if (movie == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

			await this.movieService.SoftDeleteAsync(id);

			return this.RedirectToAction(nameof(Index));
        }
	}
}

