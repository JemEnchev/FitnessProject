namespace FitnessProject.Controllers
{
    using FitnessProject.Core.Constants;
    using FitnessProject.Core.Contracts;
    using FitnessProject.Core.Models;
    using FitnessProject.Infrastructure.Data.Models;
    using FitnessProject.Infrastructure.Data.Repositories;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class SupplementController : Controller
    {
        private readonly IApplicationDbRepository repo;

        private readonly ISupplementService service;


        public SupplementController(
            IApplicationDbRepository _repo,
            ISupplementService _service)
        {
            repo = _repo;
            service = _service;
        }


        public async Task<IActionResult> AllSupplements()
        {
            var allSupplements = await service.GetAllSupplementsAsync();

            return View(allSupplements);
        }

        [Authorize(Roles = UserConstants.Roles.Nutritionist)]
        [Authorize(Roles = UserConstants.Roles.Administrator)]
        public async Task<IActionResult> AddSupplement()
        {
            ViewBag.Brands = await service.PopulateBrandsAsync();

            ViewBag.Flavours = await service.PopulateFlavourssAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSupplement(AddSupplement_VM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await service.AddSupplementAsync(model);

                    ViewData[MessageConstant.SuccessMessage] = "Supplement created successfully!";
                }
                catch (ArgumentException ax)
                {
                    ViewData[MessageConstant.ErrorMessage] = ax.Message;
                }
                catch (Exception)
                {
                    ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
                }

                var allSupplements = await service.GetAllSupplementsAsync();

                return View(nameof(AllSupplements), allSupplements);
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
            }

            return View();
        }

        [Authorize(Roles = UserConstants.Roles.Nutritionist)]
        [Authorize(Roles = UserConstants.Roles.Administrator)]
        public async Task<IActionResult> Remove(Guid supplementId)
        {
            try
            {
                await service.RemoveSupplementAsync(supplementId);

                ViewData[MessageConstant.SuccessMessage] = "Removed successfully!";
            }
            catch (Exception)
            {
                ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
            }

            var allSupplements = await service.GetAllSupplementsAsync();

            return View(nameof(AllSupplements), allSupplements);
        }

        [Authorize]
        public async Task<IActionResult> Favourites(string userEmail)
        {
            var favourites = await service.GetAllFavouritesAsync(userEmail);

            return View(favourites);
        }

        [Authorize]
        public async Task<IActionResult> AddToFavourites(Guid supplementId, string userEmail)
        {
            try
            {
                await service.AddToFavouritesAsync(supplementId, userEmail);

                ViewData[MessageConstant.SuccessMessage] = "Successfully added to favourites!";
            }
            catch (ArgumentException ax)
            {
                ViewData[MessageConstant.ErrorMessage] = ax.Message;
            }
            catch (Exception)
            {
                ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
            }

            var allSupplements = await service.GetAllSupplementsAsync();

            return View(nameof(AllSupplements), allSupplements);
        }

        [Authorize]
        public async Task<IActionResult> RemoveFromFavourites(Guid supplementId, string userEmail)
        {
            try
            {
                await service.RemoveFromFavouritesAsync(supplementId, userEmail);

                ViewData[MessageConstant.SuccessMessage] = "Successfully added to favourites!";
            }
            catch (Exception)
            {
                ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
            }

            var allSupplements = await service.GetAllSupplementsAsync();

            return View(nameof(AllSupplements), allSupplements);
        }
    }
}
