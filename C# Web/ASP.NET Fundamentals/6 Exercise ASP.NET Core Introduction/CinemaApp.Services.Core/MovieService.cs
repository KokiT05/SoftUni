using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace CinemaApp.Services.Core
{
    using static GCommon.ApplicationConstants;
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext dbContext;
        public MovieService(ApplicationDbContext applicationDbContext)
        {
            this.dbContext = applicationDbContext;
        }

        public async Task<IEnumerable<AllMoviesIndexViewModel>> GetAllMoviesAsync()
        {
            List<AllMoviesIndexViewModel> movies = await dbContext.Movies
                    .AsNoTracking()
                    .Where(m => m.IsDeleted == false) // .Where(m => !m.IsDeleted)
                    .Select(m => new AllMoviesIndexViewModel()
                    {
                        Id = m.Id.ToString(),
                        Title = m.Title,
                        Genre = m.Genre,
                        Director = m.Director,
                        ReleaseDate = m.ReleaseDate.ToString(AppDateFormat),
                        ImageUrl = m.ImageUrl ?? $"~/images/{NoImageUrl}",
                    })
                    .ToListAsync();

            return movies;
        }

        public async Task AddAsync(MovieFormViewModel model)
        {
            Movie movie = new Movie()
            {
                Title = model.Title,
                Genre = model.Genre,
                ReleaseDate = DateOnly.ParseExact(model.ReleaseDate, AppDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Description = model.Description,
                Duration = model.Duration,
                Director = model.Director,
                ImageUrl = model.ImageUrl,

            };

            await this.dbContext.Movies.AddAsync(movie);
            await this.dbContext.SaveChangesAsync();
        }

		public async Task<MovieDetailsViewModel?> GetMovieDetailsByIdAsync(string? id)
		{
            MovieDetailsViewModel? movieDetailsViewModel = null;

            bool isValidGuid = Guid.TryParse(id, out Guid movieId);
            if (isValidGuid)
            {
                movieDetailsViewModel = await this.dbContext.Movies.AsNoTracking()
                                                .Where(m => m.Id.ToString() == id && m.IsDeleted == false)
                                                .Select(m => new MovieDetailsViewModel()
                                                {
													Id = m.Id.ToString(),
													Title = m.Title,
													Genre = m.Genre,
													Director = m.Director,
													Description = m.Description,
													Duration = m.Duration,
													ReleaseDate = m.ReleaseDate.ToString(AppDateFormat),
													ImageUrl = m.ImageUrl ?? $"~/images/{NoImageUrl}"
												})
                                                .SingleOrDefaultAsync();
			}

            return movieDetailsViewModel;
		}

        public async Task<MovieFormViewModel?> GetEditableMovieByIdAsync(string? id)
        {
            MovieFormViewModel? editableMovie = null;

            bool isValidGuid = Guid.TryParse(id, out Guid movieId);
            if (isValidGuid)
            {
                editableMovie = await this.dbContext.Movies
                .AsNoTracking()
                .Where(m => m.Id.ToString() == id)
                .Select(m => new MovieFormViewModel()
                {
                    Title = m.Title,
                    Genre = m.Genre,
                    Director = m.Director,
                    Description = m.Description,
                    Duration = m.Duration,
                    ReleaseDate = m.ReleaseDate.ToString(AppDateFormat),
                    ImageUrl = m.ImageUrl ?? $"~/images/{NoImageUrl}"
                })
                .SingleOrDefaultAsync();
            }

            return editableMovie;
        }

        public async Task<bool> EditMovieAsync(MovieFormViewModel model)
        {
            //MovieFormViewModel? movieFormViewModel = null;
            Movie? movie = await this.dbContext.Movies
                                                .SingleOrDefaultAsync(m => m.Id.ToString() == model.Id);

            if (movie == null)
            {
                return false;
            }

            DateOnly movieReleaseDate = DateOnly
                            .ParseExact(model.ReleaseDate, 
                                            AppDateFormat, 
                                            CultureInfo.InvariantCulture,
                                            DateTimeStyles.None);

            movie.Title = model.Title;
            movie.Genre = model.Genre;
            movie.Director = model.Director;
            movie.Description = model.Description;
            movie.Duration = model.Duration;
            movie.ImageUrl = model.ImageUrl ?? $"~/images/{NoImageUrl}";
            movie.ReleaseDate = movieReleaseDate;

            await this.dbContext.SaveChangesAsync();


            return true;
        }
    }
}
