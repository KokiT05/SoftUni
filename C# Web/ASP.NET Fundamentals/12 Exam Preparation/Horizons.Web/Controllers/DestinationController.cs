using Horizons.Services.Core.Contracts;
using Horizons.Web.ViewModels.Destination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Horizons.Web.Controllers
{
    using static GCommon.ValidationConstatnts.DestinationConstants;
    public class DestinationController : BaseController
    {
        private readonly IDestinationService destinationService;
        private readonly ITerrainService terrainService;
        public DestinationController(IDestinationService destinationService, ITerrainService terrainService)
        {
            this.destinationService = destinationService;
            this.terrainService = terrainService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            try
            {
                string? userId = this.GetUserId();

                IEnumerable<IndexDestinationViewModel> allDestinations = await this.destinationService.GetAllDestinationAsync(userId);
                return View(allDestinations);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                AddDestinationInputModel addDestination = new AddDestinationInputModel();
                addDestination.PublishedOn = DateTime.UtcNow.ToString(PublishedOnDateFormat);
                addDestination.Terrains = await this.terrainService.GetSelectListTerrainAsync();

                return this.View(addDestination);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddDestinationInputModel inputAddDestinationModel)
        {

            try
            {
                if (ModelState.IsValid == false)
                {
                    return this.View(inputAddDestinationModel);
                }

                string userId = this.GetUserId()!;
                bool addResult = await this.destinationService.CreateDestination(inputAddDestinationModel, userId);

                if (addResult == false)
                {
                    this.ModelState.AddModelError(string.Empty, "Fatal error occurred while adding a destination!");
                    return this.View(inputAddDestinationModel);
                }

                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                string? userId = this.GetUserId();

                DetailsDestinationViewModel? detailsDestination = await this.destinationService
                                                                            .GetDetailsDestinationAsync(id, userId);

                if (detailsDestination == null)
                {
                    return this.RedirectToAction(nameof(Index)); 
                }

                return this.View(detailsDestination);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;
                EditDestinationInputModel? editDestination = await this.destinationService
                                                                        .GetEditDestinationAsync(id, userId);

                if (editDestination == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                editDestination.Terrains = await this.terrainService.GetSelectListTerrainAsync();

                return this.View(editDestination);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditDestinationInputModel inputEditDestinationModel)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    inputEditDestinationModel.Terrains = await this.terrainService.GetSelectListTerrainAsync();
                    return this.View(inputEditDestinationModel);
                }

                string userId = this.GetUserId()!;
                bool result = await this.destinationService.EditDestinationAsync(inputEditDestinationModel, userId);
                inputEditDestinationModel.Terrains = await this.terrainService.GetSelectListTerrainAsync();

                if (result == false)
                {
                    this.ModelState.AddModelError(string.Empty, "Fatal error occurred while updating the destination!");
                    return this.View(inputEditDestinationModel);
                }

                return this.RedirectToAction(nameof(Details), new {id = inputEditDestinationModel.Id});
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;

                DeleteDestinationInputModel? deleteDestinationViewModel = await this.destinationService
                                                                                   .GetDeleteDestinationAsync(id, userId);

                if (deleteDestinationViewModel == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(deleteDestinationViewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteDestinationInputModel inputDeleteDestinationModel)
        {
            try
            {
                if (this.ModelState.IsValid == false)
                {
                    this.ModelState.AddModelError(string.Empty, "Please do not modify the page!");
                    return this.View(inputDeleteDestinationModel);
                }

                string userId = this.GetUserId()!;

                bool isSuccessfyl = await this.destinationService.SoftDeleteDestinationAsync(inputDeleteDestinationModel, userId);

                if (isSuccessfyl == false)
                {
                    this.ModelState.AddModelError(string.Empty, "Fatal error occurred while deleting the destination!");
                    return this.View(inputDeleteDestinationModel);
                }

                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            try
            {
                string userId = this.GetUserId()!;
                IEnumerable<FavoritesDestinationViewModel>? favorites = await this.destinationService
                                                                                .GetUserFavoritesDestinationsAsync(userId);
                if (favorites == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(favorites);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorites(int? id)
        {
            try
            {
                if (id == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                string userId = this.GetUserId()!;

                bool addFavoriteDestinationResult =  await this.destinationService
                                                                .AddDestinationToFavoritesAsync(id.Value, userId);

                if (addFavoriteDestinationResult == false)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.RedirectToAction(nameof(Favorites));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorites(int? id)
        {
            try
            {
                if (id == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                string userId = this.GetUserId()!;

                bool removeFavoriteDestinationResult = await this.destinationService
                                                                .RemoveDestinationFromFavorite(id.Value, userId);

                if (removeFavoriteDestinationResult == false)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.RedirectToAction(nameof(Favorites));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);


                return this.RedirectToAction(nameof(Index));
            }
        }
    }
}
