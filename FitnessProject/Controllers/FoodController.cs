namespace FitnessProject.Controllers
{
    using FitnessProject.Core.Constants;
    using FitnessProject.Core.Contracts;
    using FitnessProject.Core.Models;
    using FitnessProject.Infrastructure.Data.Identity;
    using FitnessProject.Infrastructure.Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class FoodController : Controller
    {
        private readonly IFoodService service;

        public FoodController(IFoodService _service)
        {
            service = _service;
        }

        public async Task<IActionResult> AllFood()
        {
            var allFood = await service.GetAllFoodAsync();

            return View(allFood);
        }

        [Authorize]
        public async Task<IActionResult> Favourites(string userEmail)
        {
            var favourites = await service.GetAllFavouritesAsync(userEmail);

            return View(favourites);
        }

        [Authorize]
        public async Task<IActionResult> AddToFavourites(string foodName, string userEmail)
        {
            await service.AddToFavouritesAsync(foodName, userEmail);

            return RedirectToAction(nameof(AllFood));
        }

        [Authorize]
        public async Task<IActionResult> RemoveFromFavourites(string foodName, string userEmail)
        {
            await service.RemoveFromFavouritesAsync(foodName, userEmail);

            var favourites = await service.GetAllFavouritesAsync(userEmail);

            return View(nameof(Favourites), favourites);
        }

        [Authorize(Roles = UserConstants.Roles.Nutritionist)]
        [Authorize(Roles = UserConstants.Roles.Administrator)]
        public IActionResult AddFood()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFood(AddFood_VM model)
        {
            if (ModelState.IsValid)
            {
                await service.AddFoodAsync(model);

                return RedirectToAction(nameof(AllFood));
            }

            return View();
        }

        [Authorize(Roles = UserConstants.Roles.Nutritionist)]
        [Authorize(Roles = UserConstants.Roles.Administrator)]
        public async Task<IActionResult> Remove(string foodName)
        {
            if (ModelState.IsValid)
            {
                await service.RemoveFoodAsync(foodName);
            }

            return RedirectToAction(nameof(AllFood));
        }
    }
}
