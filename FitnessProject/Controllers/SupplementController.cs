namespace FitnessProject.Controllers
{
    using FitnessProject.Core.Constants;
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

        public SupplementController(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        [Authorize(Roles = UserConstants.Roles.Nutritionist)]
        [Authorize(Roles = UserConstants.Roles.Administrator)]
        public async Task<IActionResult> AddSupplement()
        {
            var vm = new AddSupplement_VM();

            vm.Brands = await repo.All<SupplementBrand>()
                          .Select(b => new SelectListItem()
                          {
                              Value = b.Id.ToString(),
                              Text = b.Name
                          })
                          .ToListAsync();

            vm.Flavours = await repo.All<SupplementFlavour>()
                          .Select(b => new SelectListItem()
                          {
                              Value = b.Id.ToString(),
                              Text = b.Name
                          })
                          .ToListAsync();

            return View(vm);
        }

        [HttpPost]
        public IActionResult AddSupplement(AddSupplement_VM model)
        {
            return View();
        }

    }
}
