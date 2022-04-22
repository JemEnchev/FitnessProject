namespace FitnessProject.Areas.Admin.Controllers
{
    using FitnessProject.Core.Contracts;
    using FitnessProject.Core.Models;
    using FitnessProject.Infrastructure.Data.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class UserManagerController : BaseController
    {
        private readonly IUserManagerService service;

        public UserManagerController(UserManager<ApplicationUser> _userManager, 
            RoleManager<IdentityRole> _roleManager,
            IUserManagerService _service)
        {
            service = _service;
        }

        public async Task<IActionResult> Index()
        {
            var users = await service.GetUsersAsync();
            return View(users);
        }

        public async Task<IActionResult> Manage(string userId)
        {
            ViewBag.userId = userId;
            var user = await service.GetUserByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }
            ViewBag.UserName = user.UserName;

            var roles = await service.ManageUserRolesAsync(user);
            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(IEnumerable<ManageUserRoles_VM> model, string userId)
        {
            var user = await service.GetUserByIdAsync(userId);

            if (user == null)
            {
                return View();
            }

            var roles = await service.GetUserRolesAsync(user);

            var result = await service.RemoveRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            result = await service.AddRolesAsync(user, model);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userEmail)
        {
            if (!string.IsNullOrEmpty(userEmail))
            {
                await service.DeleteUser(userEmail);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser()
        {
            throw new Exception();
        }
    }
}
