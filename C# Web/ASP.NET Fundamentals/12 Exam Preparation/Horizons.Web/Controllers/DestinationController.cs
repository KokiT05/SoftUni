using Horizons.Services.Core.Contracts;
using Horizons.Web.ViewModels.Destination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Horizons.Web.Controllers
{
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

                IEnumerable<IndexDestinationViewModel> allDestinations = await this.destinationService.GetAllDestination(userId);
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
            AddDestinationViewModel addDestination = new AddDestinationViewModel();
            addDestination.Terrains = await this.terrainService.GetSelectListTerrain();

            return this.View(addDestination);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddDestinationViewModel inputAddDestinationModel)
        {
            if (ModelState.IsValid == false)
            {
                return this.View();
            }

            try
            {
                string? userId = this.GetUserId();
                await this.destinationService.CreateDestination(inputAddDestinationModel, userId);

                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

                this.RedirectToAction(nameof(Index));
            }

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                string? userId = this.GetUserId();

                DetailsDestinationViewModel? detailsDestination = await this.destinationService
                                                                            .GetDetailsDestination(id, userId);

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
                string? userId = this.GetUserId();
                EditDestinationViewModel? editDestination = await this.destinationService.GetEditDestination(id, userId);

                if (editDestination == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                editDestination.Terrains = await this.terrainService.GetSelectListTerrain();

                return this.View(editDestination);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditDestinationViewModel inputEditDestinationModel)
        {
            if (ModelState.IsValid == false)
            {
                inputEditDestinationModel.Terrains = await this.terrainService.GetSelectListTerrain();
                return this.View(inputEditDestinationModel);
            }

            try
            {
                string? userId = this.GetUserId();

                bool isSuccessfyl = await this.destinationService.EditDestinationAsync(inputEditDestinationModel, userId);

                return this.RedirectToAction(nameof(Details), new {id = inputEditDestinationModel.Id});
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Details), new { id = inputEditDestinationModel.Id });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            DeleteDestinationViewModel? deleteDestination = await this.destinationService.GetDeleteDestination(id);

            string? userId = this.GetUserId();

            if (deleteDestination!= null && deleteDestination.PublisherId == userId)
            {
                return this.View(deleteDestination);
            }

            return this.RedirectToAction(nameof(Details), new { id = id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteDestinationViewModel? inputDeleteDestinationModel)
        {
            try
            {
                string? userId = this.GetUserId();

                bool isSuccessfyl = await this.destinationService.DeleteDestination(inputDeleteDestinationModel, userId);

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
                string? userId = this.GetUserId();
                IEnumerable<FavoritesDestinationViewModel>? favorites = await this.destinationService
                                                                                .GetAllFavoritesDestinations(userId);

                return this.View(favorites);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorites(int id)
        {
            try
            {
                string? userId = this.GetUserId();

                await this.destinationService.AddDestinationToFavorites(id, userId);

                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorites(int id)
        {
            try
            {
                string? userId = this.GetUserId();

                await this.destinationService.RemoveDestinationFromFavorite(id, userId);


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
