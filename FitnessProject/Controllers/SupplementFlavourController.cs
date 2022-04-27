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
        public async Task<IActionResult> AddFlavour(AddSupplementFlavour_VM model)
        {
            if (ModelState.IsValid)
            {
                await service.AddSupplementFlavourAsync(model);

                return RedirectToAction(nameof(AllFlavours));
            }

            return View();
        }

        public async Task<IActionResult> Remove(string flavourName)
        {
            if (ModelState.IsValid)
            {
                await service.RemoveSupplementFlavourAsync(flavourName);
            }

            return RedirectToAction(nameof(AllFlavours));
        }
    }
}
