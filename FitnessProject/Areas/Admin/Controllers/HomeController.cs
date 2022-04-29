namespace FitnessProject.Areas.Admin.Controllers
{
    using FitnessProject.Infrastructure.Data.Identity;
    using FitnessProject.Infrastructure.Data.Models;
    using FitnessProject.Infrastructure.Data.Repositories;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IApplicationDbRepository repo;

        public HomeController(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Users = repo.All<ApplicationUser>().Count();
            ViewBag.Supplements = repo.All<Supplement>().Count();
            ViewBag.Exercises = repo.All<Exercise>().Count();
            ViewBag.Foods = repo.All<Food>().Count();
            ViewBag.SupplementBrands = repo.All<SupplementBrand>().Count();
            ViewBag.SupplementFlavours = repo.All<SupplementFlavour>().Count();
            ViewBag.Diets = repo.All<Diet>().Count();

            return View();
        }
    }
}
