namespace FitnessProject.Controllers
{
    using FitnessProject.Core.Constants;
    using FitnessProject.Core.Contracts;
    using FitnessProject.Core.Models;
    using FitnessProject.Infrastructure.Data.Repositories;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ExerciseController : Controller
    {
        private readonly IExerciseService service;

        private readonly IApplicationDbRepository repo;


        public ExerciseController(IExerciseService _service)
        {
            service = _service;
        }

        public async Task<IActionResult> AllExercises()
        {
            var allExercises = await service.GetAllExercisesAsync();

            return View(allExercises);
        }

        [Authorize]
        public async Task<IActionResult> Favourites(string userEmail)
        {
            var favourites = await service.GetAllFavouritesAsync(userEmail);

            return View(nameof(Favourites), favourites);
        }

        [Authorize]
        public async Task<IActionResult> AddToFavourites(string exerciseName, string userEmail)
        {
            await service.AddToFavouritesAsync(exerciseName, userEmail);

            return RedirectToAction(nameof(AllExercises));
        }

        [Authorize]
        public async Task<IActionResult> RemoveFromFavourites(string foodName, string userEmail)
        {
            await service.RemoveFromFavouritesAsync(foodName, userEmail);

            var favourites = await service.GetAllFavouritesAsync(userEmail);

            return View("Favourites", favourites);
        }

        [Authorize(Roles = UserConstants.Roles.Trainer)]
        [Authorize(Roles = UserConstants.Roles.Administrator)]
        public IActionResult AddExercise()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddExercise(AddExercise_VM model)
        {
            if (ModelState.IsValid)
            {
                await service.AddExerciseAsync(model);

                return RedirectToAction(nameof(AllExercises));
            }

            return View();
        }

        [Authorize(Roles = UserConstants.Roles.Trainer)]
        [Authorize(Roles = UserConstants.Roles.Administrator)]
        public async Task<IActionResult> Remove(string exerciseName)
        {
            if (ModelState.IsValid)
            {
                await service.RemoveExerciseAsync(exerciseName);
            }

            return RedirectToAction(nameof(AllExercises));
        }
    }
}
