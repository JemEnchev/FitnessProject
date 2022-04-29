namespace FitnessProject.Areas.Admin.Controllers
{
    using FitnessProject.Core.Constants;
    using FitnessProject.Core.Contracts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class RoleManagerController : BaseController
    {
        private readonly IRoleManagerService service;


        public RoleManagerController(RoleManager<IdentityRole> _roleManager,
            IRoleManagerService _service)
        {
            service = _service;
        }


        public async Task<IActionResult> Index()
        {
            var roles = await service.GetRolesAsync();
            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName)
        {
            try
            {
                await service.CreateRoleAsync(roleName);

                ViewData[MessageConstant.SuccessMessage] = "Role added successfully!";
            }
            catch (Exception)
            {
                ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
            }

            var roles = await service.GetRolesAsync();

            return View(nameof(Index), roles);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRole(string roleName)
        {
            try
            {
                await service.RemoveRoleAsync(roleName);

                ViewData[MessageConstant.SuccessMessage] = "Role removed successfully!";
            }
            catch (Exception)
            {
                ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";
            }

            var roles = await service.GetRolesAsync();

            return View(nameof(Index), roles);
        }
    }
}
