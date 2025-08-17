using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Watchlist;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Services.Core
{
    using static CinemaApp.GCommon.ApplicationConstants;
    public class WatchlistService : IWatchlistService
    {
        private readonly ApplicationDbContext applicationDbContext;
        public WatchlistService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<WatchlistViewModel>> GetUserWatchlistAsync(string userId)
        {
            IEnumerable<WatchlistViewModel> userWatchlist = await this.applicationDbContext.UserMovies
                                .Include(um => um.Movie)
								.AsNoTracking()
								.Where(um => um.UserId.ToLower() == userId.ToLower())
                                .Select(um => new WatchlistViewModel()
                                {
                                    MovieId = um.MovieId.ToString(),
                                    Title = um.Movie.Title,
                                    Genre = um.Movie.Genre,
                                    ImageUrl = um.Movie.ImageUrl ?? $"~/images/{NoImageUrl}",
                                    ReleaseDate = um.Movie.ReleaseDate.ToString(AppDateFormat)
                                }).ToListAsync();

            return userWatchlist;

        }

        public async Task<bool> AddToWatchlistAsync(string? userId, string? movieId)
        {
            bool result = false;

            if (userId != null && movieId != null)
            {
                bool isMovieIdValid = Guid.TryParse(movieId, out Guid movieGuidId);
                if (isMovieIdValid)
                {
                    UserMovie? userMovie = await this.applicationDbContext
                                                    .UserMovies
                                                    .IgnoreQueryFilters()
                                                    .SingleOrDefaultAsync(um => um.UserId.ToLower() == userId.ToLower()
                                                     && um.MovieId.ToString() == movieGuidId.ToString());

                    if (userMovie != null)
                    {
                        userMovie.IsDeleted = false;
                    }
                    else
                    {
                        userMovie = new UserMovie()
                        {
                            UserId = userId,
                            MovieId = movieGuidId
                        };

                        await this.applicationDbContext.UserMovies.AddAsync(userMovie);
                    }

                    await this.applicationDbContext.SaveChangesAsync();
                    result = true;
                }
            }

            return result;
        }

        public async Task<bool> IsMovieInWatchlistAsync(string userId, string? movieId)
        {
            bool result = false;

            if (userId != null && movieId != null)
            {
                bool isMovieIdValid = Guid.TryParse(movieId, out Guid movieGuidId);
                if (isMovieIdValid)
                {
                    UserMovie? userMovie = await this.applicationDbContext
                                            .UserMovies
                                            .SingleOrDefaultAsync(um => um.UserId.ToLower() == userId.ToLower()
                                                     && um.MovieId.ToString() == movieGuidId.ToString());

                    if (userMovie != null)
                    {
                        result = true;
                    }
                }
            }

			return result;
		}

        public async Task<bool> RemoveFromWatchlistAsync(string? userId, string? movieId)
        {
            bool result = false;

            if (userId != null && movieId != null)
            {
                bool isMovieIdValid = Guid.TryParse(movieId, out Guid movieGuidId);
                if (isMovieIdValid)
                {
                    UserMovie? userMovie = await this.applicationDbContext
                                            .UserMovies
											.SingleOrDefaultAsync(um => um.UserId.ToLower() == userId.ToLower()
													 && um.MovieId.ToString() == movieGuidId.ToString());

                    if (userMovie != null)
                    {
                        userMovie.IsDeleted = true;

                        await this.applicationDbContext.SaveChangesAsync();

                        result = true;
                    }
				}
            }
            
            return result;
        }
    }
}
