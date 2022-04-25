namespace FitnessProject.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class AboutUsController : Controller
    {
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
