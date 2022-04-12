namespace FitnessProject.Areas.Admin.Controllers
{
    using FitnessProject.Core.Constants;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;


    [Authorize(Roles = UserConstants.Roles.Administrator)]
    [Area(AreaConstants.Admin)]
    public class BaseController : Controller
    {
        
    }
}
