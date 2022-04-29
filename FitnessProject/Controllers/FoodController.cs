namespace FitnessProject.Controllers
{
    using FitnessProject.Core.Constants;
    using FitnessProject.Core.Contracts;
    using FitnessProject.Core.Models;
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
            try
            {
                await service.AddToFavouritesAsync(foodName, userEmail);

                ViewData[MessageConstant.SuccessMessage] = "Food successfully added to favourites!";
            }
            catch (ArgumentException ax)
            {
                ViewData[MessageConstant.ErrorMessage] = ax.Message;
            }
            catch (Exception)
            {
                ViewData[MessageConstant.ErrorMessage] = "Something went wrong";
            }

            var allFood = await service.GetAllFoodAsync();

            return View(nameof(AllFood), allFood);
        }

        [Authorize]
        public async Task<IActionResult> RemoveFromFavourites(string foodName, string userEmail)
        {
            try
            {
                await service.RemoveFromFavouritesAsync(foodName, userEmail);

                ViewData[MessageConstant.SuccessMessage] = "Food successfully removed from favourites!";
            }
            catch (Exception)
            {
                ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
            }

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
                try
                {
                    await service.AddFoodAsync(model);

                    ViewData[MessageConstant.SuccessMessage] = "Food added successfully!";
                }
                catch (Exception x)
                {
                    if (x.Message == "Food already added!")
                    {
                        ViewData[MessageConstant.ErrorMessage] = "Food already exists!";
                    }
                    else
                    {
                        ViewData[MessageConstant.ErrorMessage] = "Something went wrong";
                    }

                }

                var allFood = await service.GetAllFoodAsync();

                return View(nameof(AllFood), allFood);
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
            }

            return View();
        }

        [Authorize(Roles = UserConstants.Roles.Nutritionist)]
        [Authorize(Roles = UserConstants.Roles.Administrator)]
        public async Task<IActionResult> Remove(string foodName)
        {
            try
            {
                await service.RemoveFoodAsync(foodName);

                ViewData[MessageConstant.SuccessMessage] = "Food removed successfully!";
            }
            catch (Exception)
            {
                ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
            }

            var allFood = await service.GetAllFoodAsync();

            return View(nameof(AllFood), allFood);
        }
    }
}
