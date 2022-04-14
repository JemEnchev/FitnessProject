namespace FitnessProject.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class UserController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
