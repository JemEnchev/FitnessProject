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
            try
            {
                await service.AddToFavouritesAsync(exerciseName, userEmail);

                ViewData[MessageConstant.SuccessMessage] = "Exercise added successfully!";
            }
            catch (ArgumentException ax)
            {
                ViewData[MessageConstant.ErrorMessage] = ax.Message;
            }
            catch (Exception)
            {
                ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
            }

            var allExercises = await service.GetAllExercisesAsync();

            return View(nameof(AllExercises), allExercises);
        }

        [Authorize]
        public async Task<IActionResult> RemoveFromFavourites(string exerciseName, string userEmail)
        {
            try
            {
                await service.RemoveFromFavouritesAsync(exerciseName, userEmail);

                ViewData[MessageConstant.SuccessMessage] = "Removed successfully!";
            }
            catch (Exception)
            {
                ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
            }

            var allExercises = await service.GetAllExercisesAsync();

            return View(nameof(AllExercises), allExercises);
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
                try
                {
                    await service.AddExerciseAsync(model);

                    ViewData[MessageConstant.SuccessMessage] = "Exercise created successfully!";
                }
                catch (ArgumentException ax)
                {
                    ViewData[MessageConstant.ErrorMessage] = ax.Message;
                }
                catch (Exception)
                {
                    ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
                }

                var allExercises = await service.GetAllExercisesAsync();

                return View(nameof(AllExercises), allExercises);
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
            }

            return View();
        }

        [Authorize(Roles = UserConstants.Roles.Trainer)]
        [Authorize(Roles = UserConstants.Roles.Administrator)]
        public async Task<IActionResult> Remove(string exerciseName)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await service.RemoveExerciseAsync(exerciseName);

                    ViewData[MessageConstant.SuccessMessage] = "Exercise removed successfully!";
                }
                catch (Exception)
                {
                    ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
                }
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
            }

            var allExercises = await service.GetAllExercisesAsync();

            return View(nameof(AllExercises), allExercises);
        }

        public async Task<IActionResult> ExerciseInfo(string exerciseName, string targetView)
        {
            if (ModelState.IsValid)
            {
                var exercise = await service.GetExerciseByNameAsync(exerciseName);

                return View(targetView, exercise);
            }

            return RedirectToAction(nameof(AllExercises));
        }
    }
}
