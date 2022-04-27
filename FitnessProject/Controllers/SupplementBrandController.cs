namespace FitnessProject.Controllers
{
    using FitnessProject.Core.Constants;
    using FitnessProject.Core.Contracts;
    using FitnessProject.Core.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = UserConstants.Roles.Nutritionist)]
    [Authorize(Roles = UserConstants.Roles.Administrator)]
    public class SupplementBrandController : Controller
    {
        private readonly ISupplementBrandService service;

        public SupplementBrandController(ISupplementBrandService _service)
        {
            service = _service;
        }

        public async Task<IActionResult> AllBrands()
        {
            var allBrands = await service.GetAllSupplementBrandsAsync();

            return View(allBrands);
        }

        public IActionResult AddBrand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBrand(AddSupplementBrand_VM model)
        {
            if (ModelState.IsValid)
            {
                await service.AddSupplementBrandAsync(model);

                return RedirectToAction(nameof(AllBrands));
            }

            return View();
        }

        public async Task<IActionResult> Remove(string brandName)
        {
            if (ModelState.IsValid)
            {
                await service.RemoveSupplementBrandAsync(brandName);
            }

            return RedirectToAction(nameof(AllBrands));
        }
    }
}
