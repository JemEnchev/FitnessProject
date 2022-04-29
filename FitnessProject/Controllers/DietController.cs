namespace FitnessProject.Controllers
{
    using FitnessProject.Core.Constants;
    using FitnessProject.Core.Contracts;
    using FitnessProject.Core.Models.Diet;
    using FitnessProject.Infrastructure.Data.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    public class DietController : Controller
    {
        private readonly IDietService service;

        private readonly UserManager<ApplicationUser> userManager;

        public DietController(
            IDietService _service,
            UserManager<ApplicationUser> _userManager)
        {
            service = _service;
            userManager = _userManager;
        }


        public async Task<IActionResult> MyDiets()
        {
            var allDiets = await service.GetAllDietsAsync(User.Identity?.Name);

            return View(allDiets);
        }

        public IActionResult CreateDiet()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiet(Diet_VM model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                try
                {
                    await service.CreateDietAsync(model, userId);

                    ViewData[MessageConstant.SuccessMessage] = "Diet created successfully!";
                }
                catch (ArgumentException ax)
                {
                    ViewData[MessageConstant.ErrorMessage] = ax.Message;
                }
                catch (Exception)
                {
                    ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
                }
                

                var allDiets = await service.GetAllDietsAsync(User.Identity?.Name);

                return View(nameof(MyDiets), allDiets);
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
            }


            return View();
        }

        public async Task<IActionResult> Delete(string dietName)
        {
            try
            {
                await service.DeleteDietAsync(dietName);

                ViewData[MessageConstant.SuccessMessage] = "Diet deletd successfully!";
            }
            catch (Exception)
            {
                ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
            }
            
            var allDiets = await service.GetAllDietsAsync(User.Identity?.Name);

            return View(nameof(MyDiets), allDiets);

        }

        public async Task<IActionResult> DietInfo(string dietName)
        {
            if (ModelState.IsValid)
            {
                var diet = await service.GetDietByNameAsync(dietName);

                return View(diet);
            }

            var allDiets = await service.GetAllDietsAsync(User.Identity?.Name);

            return View(nameof(MyDiets), allDiets);
        }

    }
}
