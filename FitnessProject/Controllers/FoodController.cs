namespace FitnessProject.Controllers
{
    using FitnessProject.Core.Models;
    using Microsoft.AspNetCore.Mvc;

    public class FoodController : Controller
    {
        public IActionResult AllFood()
        {
            return View();
        }

        public IActionResult Favourites()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddFood_VM model)
        {
            return View();
        }
    }
}
