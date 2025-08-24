using Horizons.Data;
using Horizons.Data.Models;
using Horizons.Services.Core.Contracts;
using Horizons.Web.ViewModels.Destination;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.Services.Core
{
    using static GCommon.ValidationConstatnts.DestinationConstants;
    public class DestinationService : IDestinationService
    {
        private readonly ApplicationDbContext applicationDbContext;
        public DestinationService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<IndexDestinationViewModel>> GetAllDestination(string? userId)
        {
            IEnumerable<IndexDestinationViewModel> allDestination = await this.applicationDbContext.Destinations
                                                                    .Include(d => d.Terrain)
                                                                    .Include(d => d.UsersDestinations)
                                                                    .AsNoTracking()
                                                                    .Select(d => new IndexDestinationViewModel()
                                                                    {
                                                                        Id = d.Id,
                                                                        Name = d.Name,
                                                                        Description = d.Description,
                                                                        ImageUrl = d.ImageUrl,
                                                                        Terrain = d.Terrain.Name,
                                                                        FavoritesCount = d.UsersDestinations.Count(ud => ud.DestinationId == d.Id),
                                                                        IsFavorite = d.UsersDestinations.Any(ud => ud.DestinationId == d.Id && ud.UserId == userId),
                                                                        IsPublisher = (d.PublisherId == userId) ? true : false,

                                                                    }).ToListAsync();

            return allDestination;
        }

        public async Task CreateDestination(AddDestinationViewModel inputAddDestinationModel, string? userId)
        {
            bool isSuccessful = DateTime.TryParseExact
                                        (inputAddDestinationModel.PublishedOn, 
                                        PublishedOnDateFormat, 
                                        CultureInfo.CurrentCulture, 
                                        DateTimeStyles.None, 
                                        out DateTime resultDateTime);
            
            if (isSuccessful == false || userId == null)
            {
                return;
            }

            Destination destination = new Destination()
            {
                Name = inputAddDestinationModel.Name,
                Description = inputAddDestinationModel.Description,
                ImageUrl = inputAddDestinationModel.ImageUrl,
                PublisherId = userId,
                PublishedOn = resultDateTime,
                TerrainId = inputAddDestinationModel.TerrainId,
            };

            await this.applicationDbContext.Destinations.AddAsync(destination);
            await this.applicationDbContext.SaveChangesAsync();
        }

        public async Task<DetailsDestinationViewModel?> GetDetailsDestination(int? destinationId, string? userId)
        {
            DetailsDestinationViewModel? detailsDestination = null;

            if (destinationId != null)
            {
                detailsDestination = await this.applicationDbContext
                                            .Destinations
                                            .Include(d => d.UsersDestinations)
                                            .Include(d => d.Terrain)
                                            .AsNoTracking()
                                            .Where(d => d.Id == destinationId)
                                            .Select(d => new DetailsDestinationViewModel()
                                            {
                                                Id = d.Id,
                                                Name = d.Name,
                                                Description = d.Description,
                                                ImageUrl = d.ImageUrl,
                                                PublishedOn = d.PublishedOn,
                                                Terrain = d.Terrain.Name,
                                                Publisher = d.Publisher.UserName,
                                                IsPublisher = (d.PublisherId == userId) ? true : false,
                                                IsFavorite = d.UsersDestinations.Any(ud => ud.DestinationId == destinationId)
                                            }).SingleOrDefaultAsync();
                             
            }

            return detailsDestination;
        }

        public async Task<EditDestinationViewModel?> GetEditDestination(int? destinationId, string? userId)
        {
            Destination? destination = await this.applicationDbContext.Destinations
                                                                     .AsNoTracking()
                                                                     .Where(d => d.Id == destinationId)
                                                                     .SingleOrDefaultAsync();

            EditDestinationViewModel? editDestination = null;

            if (destination != null && destination.PublisherId == userId)
            {
                editDestination = new EditDestinationViewModel()
                {
                    Id = destination.Id,
                    Name = destination.Name,
                    PublishedOn = destination.PublishedOn.ToString(PublishedOnDateFormat),
                    PublisherId = destination.PublisherId,
                    Description = destination.Description,
                    ImageUrl = destination.ImageUrl,
                    TerrainId = destination.TerrainId,
                };
            }

            return editDestination;

        }

        public async Task<bool> EditDestinationAsync(EditDestinationViewModel editDestinationViewModel, string? userId)
        {
            bool isEditSuccessfyl = false;

            Destination? destination = await this.applicationDbContext
                                                .Destinations
                                                .Where(d => d.Id == editDestinationViewModel.Id)
                                                .SingleOrDefaultAsync();

            if (destination != null && destination.PublisherId == userId)
            {
                destination.Name = editDestinationViewModel.Name;
                destination.Description = editDestinationViewModel.Description;
                destination.ImageUrl = editDestinationViewModel.ImageUrl;
                destination.PublishedOn = DateTime.Parse(editDestinationViewModel.PublishedOn);
                destination.TerrainId = editDestinationViewModel.TerrainId;

                await this.applicationDbContext.SaveChangesAsync();

                isEditSuccessfyl = true;
            }

            return isEditSuccessfyl;
        }

        public async Task<DeleteDestinationViewModel?> GetDeleteDestination(int? destinationId)
        {
            DeleteDestinationViewModel? deleteDestination = await this.applicationDbContext
                                                                    .Destinations
                                                                    .Include(d => d.Publisher)
                                                                    .AsNoTracking()
                                                                    .Where(d => d.Id == destinationId)
                                                                    .Select(d => new DeleteDestinationViewModel()
                                                                    {
                                                                        Id = d.Id,
                                                                        Name = d.Name,
                                                                        PublisherId = d.PublisherId,
                                                                        Publisher = d.Publisher.UserName,
                                                                    })
                                                                    .SingleOrDefaultAsync();

            return deleteDestination;
        }

        public async Task<bool> DeleteDestination(DeleteDestinationViewModel? inputDeleteDestinationModel, string? userId)
        {
            Destination? destination = await this.applicationDbContext
                                                        .Destinations
                                                        .Where(ud => ud.Id == inputDeleteDestinationModel.Id)
                                                        .SingleOrDefaultAsync();

            if (destination != null && destination.PublisherId == userId)
            {
                destination.IsDeleted = true;
                await this.applicationDbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<FavoritesDestinationViewModel>?> GetAllFavoritesDestinations(string? userId)
        {
            IEnumerable<FavoritesDestinationViewModel> favoritesDestinations = await this.applicationDbContext
                                                                            .UsersDestinations
                                                                            .Include(ud => ud.Destination)
                                                                            .Include(ud => ud.Destination.Terrain)
                                                                            .AsNoTracking()
                                                                            .Where(ud => ud.UserId == userId)
                                                                            .Select(ud => new FavoritesDestinationViewModel()
                                                                            {
                                                                                Id = ud.Destination.Id,
                                                                                Name = ud.Destination.Name,
                                                                                ImageUrl = ud.Destination.ImageUrl,
                                                                                Terrain = ud.Destination.Terrain.Name
                                                                            }).ToListAsync();

            return favoritesDestinations;
        }

        public async Task AddDestinationToFavorites(int destinationId, string? userId)
        {
            bool isValidUserId = Guid.TryParse(userId, out Guid validUserId);
            bool isDestinationExist = await this.applicationDbContext.Destinations
                                                                    .AsNoTracking()
                                                                    .AnyAsync(d => d.Id == destinationId);
            if (isValidUserId && isDestinationExist)
            {
                bool isAlreadyAddToFavorite = await this.applicationDbContext.UsersDestinations
                                                            .AsNoTracking()
                                                            .AnyAsync(ud => ud.UserId == userId && ud.DestinationId == destinationId);
                if (isAlreadyAddToFavorite == false)
                {
                    UserDestination userDestination = new UserDestination()
                    {
                        UserId = userId,
                        DestinationId = destinationId,
                    };

                    await this.applicationDbContext.UsersDestinations.AddAsync(userDestination);
                    await this.applicationDbContext.SaveChangesAsync();
                }
            }
        }

        public async Task RemoveDestinationFromFavorite(int? destinationId, string? userId)
        {
            UserDestination? userDestination = await this.applicationDbContext
                                                        .UsersDestinations
                                                        .Where(ud => ud.DestinationId == destinationId &&
                                                                ud.UserId == userId)
                                                        .SingleOrDefaultAsync();

            if (userDestination != null)
            {
                this.applicationDbContext.UsersDestinations.Remove(userDestination);
                await this.applicationDbContext.SaveChangesAsync();
            }
        }
    }
}
