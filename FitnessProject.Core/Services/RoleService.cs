namespace FitnessProject.Core.Services
{
    using FitnessProject.Core.Constants;
    using FitnessProject.Core.Contracts;
    using FitnessProject.Core.Models;
    using FitnessProject.Infrastructure.Data.Repositories;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly IApplicationDbRepository repo;

        public RoleService(RoleManager<IdentityRole> _roleManager,
            IApplicationDbRepository _repo)
        {
            roleManager = _roleManager;
            repo = _repo;
        }


        public async Task<IEnumerable<IdentityRole>> GetRolesAsync()
        {
            return await roleManager.Roles.ToListAsync();
        }


        public async Task CreateRoleAsync(string name)
        {
            if (name != null)
            {
               await roleManager.CreateAsync(new IdentityRole(name.Trim()));
            }
        }
        

        public async Task RemoveRoleAsync(string name)
        {
            if (name != null)
            {
                // For safety reasons admins cannot remove Administrator and User role
                // This may break the other logic
                var role = await roleManager.FindByNameAsync(name);
                if (role != null && 
                    role.Name != UserConstants.Roles.Administrator &&
                    role.Name != UserConstants.Roles.User)
                {
                    await roleManager.DeleteAsync(role);
                }
            }
        }
    }
}
