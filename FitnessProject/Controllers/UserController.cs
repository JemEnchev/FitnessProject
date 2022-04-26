namespace FitnessProject.Controllers
{
    using FitnessProject.Core.Constants;
    using FitnessProject.Core.Contracts;
    using FitnessProject.Infrastructure.Data.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;


    public class UserController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<ApplicationUser> userManager;

        private readonly IUserManagerService service;

        public UserController(RoleManager<IdentityRole> _roleManager,
            UserManager<ApplicationUser> _userManager,
            IUserManagerService _service)
        {
            roleManager = _roleManager;
            userManager = _userManager;
            service = _service;
        }


       
    }
}
