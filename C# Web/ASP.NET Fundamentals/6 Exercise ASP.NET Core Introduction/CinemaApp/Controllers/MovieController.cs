using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Web.Controllers
{
	public class MovieController : Controller
	{
		private readonly ApplicationDbContext dbContext;

        public MovieController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
		{
			List<AllMoviesIndexViewModel> movies = await dbContext.Movies
								.AsNoTracking()
								.Select(m => new AllMoviesIndexViewModel()
								{
									Id = m.Id.ToString(),
									Title = m.Title,
									Genre = m.Genre,
									Director = m.Director,
									ReleaseDate = m.ReleaseDate.ToString("yyyy-MM-dd"),
									ImageUrl = m.ImageUrl,
								})
								.ToListAsync();

			return View(movies);
		}
	}
}
