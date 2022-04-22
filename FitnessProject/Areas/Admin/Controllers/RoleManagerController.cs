namespace FitnessProject.Areas.Admin.Controllers
{
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
            await service.CreateRoleAsync(roleName);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRole(string roleName)
        {
            await service.RemoveRoleAsync(roleName);
            return RedirectToAction("Index");
        }
    }
}
