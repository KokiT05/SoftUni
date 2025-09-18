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
        private readonly UserManager<IdentityUser> userManager;
        public DestinationService(ApplicationDbContext applicationDbContext, UserManager<IdentityUser> userManager)
        {
            this.applicationDbContext = applicationDbContext;
            this.userManager = userManager;
        }

        public async Task<IEnumerable<IndexDestinationViewModel>> GetAllDestinationAsync(string? userId)
        {

            IEnumerable<IndexDestinationViewModel> allDestination = await this.applicationDbContext.Destinations
                    .Include(d => d.Terrain)
                    .Include(d => d.UsersDestinations)
                    .AsNoTracking()
                    .Select(d => new IndexDestinationViewModel()
                    {
                        Id = d.Id,
                        Name = d.Name,
                        //Description = EditDestinationInputModel.Description,
                        ImageUrl = d.ImageUrl,
                        Terrain = d.Terrain.Name,
                        FavoritesCount = d.UsersDestinations.Count,
                        IsFavorite = userId != null ?
                                    d.UsersDestinations.Any(ud => ud.UserId.ToLower() == userId!.ToLower()) : false,
                        IsPublisher = userId != null ? 
                                    d.PublisherId.ToLower() == userId!.ToLower() : false,

                    }).ToListAsync();

            return allDestination;
        }

        public async Task<bool> CreateDestination(AddDestinationInputModel inputAddDestinationModel, string userId)
        {
            bool result = false;

            IdentityUser? user = await this.userManager.FindByIdAsync(userId);
            Terrain? terrain = await this.applicationDbContext.Terrains.FindAsync(inputAddDestinationModel.TerrainId);
            bool isPublishedOnDateValid = DateTime.TryParseExact(inputAddDestinationModel.PublishedOn,
                                                                    PublishedOnDateFormat, 
                                                                    CultureInfo.InvariantCulture, 
                                                                    DateTimeStyles.None, 
                                                                    out DateTime publishedOnDate);

            if ((user != null) && (terrain != null) && isPublishedOnDateValid)
            {
                Destination destination = new Destination()
                {
                    Name = inputAddDestinationModel.Name,
                    Description = inputAddDestinationModel.Description,
                    ImageUrl = inputAddDestinationModel.ImageUrl,
                    PublisherId = userId,
                    PublishedOn = publishedOnDate,
                    TerrainId = inputAddDestinationModel.TerrainId,
                };


                await this.applicationDbContext.Destinations.AddAsync(destination);
                await this.applicationDbContext.SaveChangesAsync();

                result = true;
            }

            return result;

            //bool isSuccessful = DateTime.TryParseExact
            //                            (inputAddDestinationModel.PublishedOn, 
            //                            PublishedOnDateFormat, 
            //                            CultureInfo.CurrentCulture, 
            //                            DateTimeStyles.None, 
            //                            out DateTime resultDateTime);
            
            //if (isSuccessful == false || userId == null)
            //{
            //    return false;
            //}

            //Destination destination = new Destination()
            //{
            //    Name = inputAddDestinationModel.Name,
            //    Description = inputAddDestinationModel.Description,
            //    ImageUrl = inputAddDestinationModel.ImageUrl,
            //    PublisherId = userId,
            //    PublishedOn = resultDateTime,
            //    TerrainId = inputAddDestinationModel.TerrainId,
            //};
        }

        public async Task<DetailsDestinationViewModel?> GetDetailsDestinationAsync(int? destinationId, string? userId)
        {
            DetailsDestinationViewModel? detailsDestination = null;

            if (destinationId.HasValue)
            {
                Destination? destination = await this.applicationDbContext
                                                    .Destinations
                                                    .Include(d => d.Terrain)
                                                    .Include(d => d.Publisher)
                                                    .Include(d => d.UsersDestinations)
                                                    .AsNoTracking()
                                                    .SingleOrDefaultAsync(d => d.Id == destinationId.Value);

                if (destination != null)
                {
                    detailsDestination = new DetailsDestinationViewModel()
                    {
                        Id = destination.Id,
                        Name = destination.Name,
                        ImageUrl = destination.ImageUrl,
                        Description = destination.Description,
                        PublishedOn = destination.PublishedOn,
                        Terrain = destination.Terrain.Name,
                        Publisher = destination.Publisher.UserName,
                        IsPublisher = userId != null ? destination.PublisherId.ToLower() == userId.ToLower() : false,
                        IsFavorite = userId != null ?
                        destination.UsersDestinations.Any(ud => ud.UserId.ToLower() == userId.ToLower()) : false

                    };
                }

                //detailsDestination = await this.applicationDbContext
                //                            .Destinations
                //                            .Include(EditDestinationInputModel => EditDestinationInputModel.UsersDestinations)
                //                            .Include(EditDestinationInputModel => EditDestinationInputModel.Terrain)
                //                            .AsNoTracking()
                //                            .Where(EditDestinationInputModel => EditDestinationInputModel.Id == destinationId)
                //                            .Select(EditDestinationInputModel => new DetailsDestinationViewModel()
                //                            {
                //                                Id = EditDestinationInputModel.Id,
                //                                Name = EditDestinationInputModel.Name,
                //                                Description = EditDestinationInputModel.Description,
                //                                ImageUrl = EditDestinationInputModel.ImageUrl,
                //                                PublishedOn = EditDestinationInputModel.PublishedOn,
                //                                Terrain = EditDestinationInputModel.Terrain.Name,
                //                                Publisher = EditDestinationInputModel.Publisher.UserName,
                //                                IsPublisher = (EditDestinationInputModel.PublisherId == userId) ? true : false,
                //                                IsFavorite = EditDestinationInputModel.UsersDestinations.Any(ud => ud.DestinationId == destinationId)
                //                            }).SingleOrDefaultAsync();
                             
            }

            return detailsDestination;
        }

        public async Task<EditDestinationInputModel?> GetEditDestinationAsync(int? destinationId, string userId)
        {
            EditDestinationInputModel? editDestination = null;
            if (destinationId != null)
            {
                Destination? destination = await this.applicationDbContext.Destinations
                                                            .AsNoTracking()
                                                            .SingleOrDefaultAsync(d => d.Id == destinationId);

                if ((destination != null) && (destination.PublisherId.ToLower() == userId.ToLower()))
                {
                    editDestination = new EditDestinationInputModel()
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
            }

            return editDestination;

        }

        public async Task<bool> EditDestinationAsync(EditDestinationInputModel editDestinationInputModell, string? userId)
        {

            bool result = false;

            Destination? destination = await this.applicationDbContext.Destinations
                                                                    .FindAsync(editDestinationInputModell.Id);

            IdentityUser? user = await this.userManager.FindByIdAsync(userId);
            Terrain? terrain = await this.applicationDbContext.Terrains.FindAsync(editDestinationInputModell.TerrainId);
            bool isPublishedOnDateValid = DateTime.TryParseExact(editDestinationInputModell.PublishedOn,
                                                                    PublishedOnDateFormat,
                                                                    CultureInfo.InvariantCulture,
                                                                    DateTimeStyles.None,
                                                                    out DateTime publishedOnDate);

            if ((user != null) && 
                (destination != null) && 
                (terrain != null) &&
                (isPublishedOnDateValid) &&
                (destination.PublisherId.ToLower() == userId.ToLower()))
            {
                destination.Name = editDestinationInputModell.Name;
                destination.Description = editDestinationInputModell.Description;
                destination.ImageUrl = editDestinationInputModell.ImageUrl;
                destination.PublishedOn = publishedOnDate;
                destination.TerrainId = editDestinationInputModell.TerrainId;

                await this.applicationDbContext.SaveChangesAsync();

                result = true;
            }

            return result;
        }

        public async Task<DeleteDestinationInputModel?> GetDeleteDestinationAsync(int? destinationId, string userId)  
        {
            DeleteDestinationInputModel? deleteDestination = null;
            if (destinationId != null)
            {
                Destination? destination = await this.applicationDbContext.Destinations
                                                                        .Include(d => d.Publisher)
                                                                        .AsNoTracking()
                                                                        .SingleOrDefaultAsync(d => d.Id ==  destinationId);

                if ((destination != null) && (destination.PublisherId.ToLower() == userId.ToLower()))
                {
                    deleteDestination = new DeleteDestinationInputModel()
                    {
                        Id = destination.Id,
                        Name = destination.Name,
                        Publisher = destination.Publisher.NormalizedUserName,
                        PublisherId = destination.PublisherId,
                    };
                }
            }

            return deleteDestination;
        }

        public async Task<bool> SoftDeleteDestinationAsync(DeleteDestinationInputModel inputDeleteDestinationModel, string userId)
        {
            bool result = false;

            Destination? destination = await this.applicationDbContext.Destinations
                                                                    .FindAsync(inputDeleteDestinationModel.Id);

            IdentityUser? user = await this.userManager.FindByIdAsync(userId);

            if ((user != null) && (destination != null) &&
                (destination.PublisherId.ToLower() == userId.ToLower()))
            {
                destination.IsDeleted = true;

                await this.applicationDbContext.SaveChangesAsync();

                result = true;
            }

            return result;

        }

        public async Task<IEnumerable<FavoritesDestinationViewModel>?> GetUserFavoritesDestinationsAsync(string userId)
        {
            IEnumerable<FavoritesDestinationViewModel> favoritesDestinations = null;

            IdentityUser? user = await this.userManager.FindByIdAsync(userId);

            if (user != null)
            {
                favoritesDestinations = await this.applicationDbContext
                                                                .UsersDestinations
                                                                .Include(ud => ud.Destination)
                                                                .ThenInclude(d => d.Terrain)
                                                                .AsNoTracking()
                                                                .Where(ud => ud.UserId.ToLower() == userId.ToLower())
                                                                .Select(ud => new FavoritesDestinationViewModel()
                                                                {
                                                                    Id = ud.Destination.Id,
                                                                    Name = ud.Destination.Name,
                                                                    ImageUrl = ud.Destination.ImageUrl,
                                                                    Terrain = ud.Destination.Terrain.Name
                                                                }).ToListAsync();
            }

            return favoritesDestinations;
        }

        public async Task<bool> AddDestinationToFavoritesAsync(int destinationId, string userId)
        {
            bool result = false;

            Destination? destination = await this.applicationDbContext.Destinations
                                                                    .FindAsync(destinationId);

            IdentityUser? user = await this.userManager.FindByIdAsync(userId);

            if ((user != null) && (destination != null) && (destination.PublisherId.ToLower() != userId.ToLower()))
            {
                UserDestination? UserFavoriteDestination = await this.applicationDbContext.UsersDestinations
                    .SingleOrDefaultAsync(ud => ud.UserId.ToLower() == userId.ToLower() &&
                    ud.DestinationId == destinationId);

                if (UserFavoriteDestination == null)
                {
                    UserFavoriteDestination = new UserDestination()
                    {
                        UserId = userId,
                        DestinationId = destinationId
                    };

                    await this.applicationDbContext.UsersDestinations.AddAsync(UserFavoriteDestination);
                    await this.applicationDbContext.SaveChangesAsync();

                    result = true;
                }
            }

            return result;
        }

        public async Task<bool> RemoveDestinationFromFavorite(int destinationId, string userId)
        {
            bool result = false;

                UserDestination? UserFavoriteDestination = await this.applicationDbContext.UsersDestinations
                    .SingleOrDefaultAsync(ud => ud.UserId.ToLower() == userId.ToLower() &&
                    ud.DestinationId == destinationId);

                if (UserFavoriteDestination != null)
                {

                    this.applicationDbContext.UsersDestinations.Remove(UserFavoriteDestination);
                    await this.applicationDbContext.SaveChangesAsync();

                    result = true;
                }

            return result;
        }
    }
}
