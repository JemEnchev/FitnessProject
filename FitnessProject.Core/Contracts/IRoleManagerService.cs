namespace FitnessProject.Core.Contracts
{
    using FitnessProject.Core.Models;
    using Microsoft.AspNetCore.Identity;

    public interface IRoleManagerService
    {
        Task<IEnumerable<IdentityRole>> GetRolesAsync();

        Task CreateRoleAsync(string name);

        Task RemoveRoleAsync(string name);
    }
}
