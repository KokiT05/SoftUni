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
            return await this.applicationDbContext.UserMovies
                                .Where(um => um.UserId == userId)
                                .Select(um => new WatchlistViewModel()
                                {
                                    MovieId = um.MovieId.ToString(),
                                    Title = um.Movie.Title,
                                    Genre = um.Movie.Genre,
                                    ImageUrl = um.Movie.ImageUrl,
                                    ReleaseDate = um.Movie.ReleaseDate.ToString(AppDateFormat)
                                }).ToListAsync();

        }

        public async Task AddToWatchlistAsync(string userId, string movieId)
        {
            UserMovie userMovie = new UserMovie()
            {
                UserId = userId,
                MovieId = Guid.Parse(movieId),
            };

            await this.applicationDbContext.UserMovies.AddAsync(userMovie);
            await this.applicationDbContext.SaveChangesAsync();
        }

        public async Task<bool> IsMovieInWatchlistAsync(string userId, Guid movieId)
        {
            return await this.applicationDbContext.UserMovies
                            .AnyAsync(um => um.UserId == userId && um.MovieId == movieId);
        }

        public async Task RemoveFromWatchlistAsync(string userId, string movieId)
        {
            UserMovie? userMovie = await this.applicationDbContext.UserMovies
                    .FirstOrDefaultAsync(um => um.UserId == userId && um.MovieId == Guid.Parse(movieId));

            if (userMovie != null)
            {
                this.applicationDbContext.UserMovies.Remove(userMovie);
                await this.applicationDbContext.SaveChangesAsync();
            }
        }
    }
}
