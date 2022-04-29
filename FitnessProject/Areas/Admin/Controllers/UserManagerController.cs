namespace FitnessProject.Areas.Admin.Controllers
{
    using FitnessProject.Core.Constants;
    using FitnessProject.Core.Contracts;
    using FitnessProject.Core.Models;
    using FitnessProject.Infrastructure.Data.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

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
                ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
                return View(nameof(NotFound));
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
                ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
                return View();
            }

            var roles = await service.GetUserRolesAsync(user);

            var result = await service.RemoveRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ViewData[MessageConstant.ErrorMessage] = "An error occured!";
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            result = await service.AddRolesAsync(user, model);
            if (!result.Succeeded)
            {
                ViewData[MessageConstant.ErrorMessage] = "An error occured!";
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }

            ViewData[MessageConstant.SuccessMessage] = "Successfully editted user roles!";

            var users = await service.GetUsersAsync();

            return View(nameof(Index), users);
        }

        public async Task<IActionResult> DeleteUser(string userEmail)
        {
            if (!string.IsNullOrEmpty(userEmail))
            {
                try
                {
                    await service.DeleteUserAsync(userEmail);

                    ViewData[MessageConstant.SuccessMessage] = "User deleted successfully!";
                }
                catch (Exception)
                {
                    ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
                }
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
            }

            var users = await service.GetUsersAsync();

            return View(nameof(Index), users);
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUser_VM model)
        {
            if (ModelState.IsValid)
            {
                await service.CreateUserAsync(model);

                //if (!result.Succeeded)
                //{
                //    foreach (IdentityError error in result.Errors)
                //        ModelState.AddModelError("", error.Description);
                //}
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
