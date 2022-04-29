namespace FitnessProject.Controllers
{
    using FitnessProject.Core.Constants;
    using FitnessProject.Core.Contracts;
    using FitnessProject.Core.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = UserConstants.Roles.Nutritionist)]
    [Authorize(Roles = UserConstants.Roles.Administrator)]
    public class SupplementFlavourController : Controller
    {
        private readonly ISupplementFlavourService service;

        public SupplementFlavourController(ISupplementFlavourService _service)
        {
            service = _service;
        }

        public async Task<IActionResult> AllFlavours()
        {
            var allFlavours = await service.GetAllSupplementFlavoursAsync();

            return View(allFlavours);
        }

        public IActionResult AddFlavour()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFlavour(AddFlavour_VM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await service.AddSupplementFlavourAsync(model);

                    ViewData[MessageConstant.SuccessMessage] = "Flavour added successfully!";
                }
                catch (ArgumentNullException ax)
                {
                    ViewData[MessageConstant.ErrorMessage] = ax.Message;
                }
                catch (Exception)
                {
                    ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
                }

                var allFlavours = await service.GetAllSupplementFlavoursAsync();

                return View(nameof(AllFlavours), allFlavours);
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
            }

            return View();
        }

        public async Task<IActionResult> Remove(string flavourName)
        {
                try
                {
                    await service.RemoveSupplementFlavourAsync(flavourName);

                    ViewData[MessageConstant.SuccessMessage] = "Flavour removed successfully!";
                }
                catch (Exception)
                {
                    ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
                }

            var allFlavours = await service.GetAllSupplementFlavoursAsync();

            return View(nameof(AllFlavours), allFlavours);
        }
    }
}
