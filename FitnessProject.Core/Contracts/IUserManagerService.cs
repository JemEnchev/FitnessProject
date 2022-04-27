namespace FitnessProject.Core.Contracts
{
    using FitnessProject.Core.Models;
    using FitnessProject.Infrastructure.Data.Identity;
    using Microsoft.AspNetCore.Identity;

    public interface IUserManagerService
    {
        Task<IEnumerable<UserRoles_VM>> GetUsersAsync();

        Task<IEnumerable<string>> GetUserRolesAsync(ApplicationUser user);

        Task<ApplicationUser> GetUserByIdAsync(string userId);

        Task<ApplicationUser> GetUserByEmailAsync(string userEmail);

        Task<IEnumerable<ManageUserRoles_VM>> ManageUserRolesAsync(ApplicationUser user);

        Task<IdentityResult> AddRolesAsync(ApplicationUser user, IEnumerable<ManageUserRoles_VM> model);

        Task<IdentityResult> RemoveRolesAsync(ApplicationUser user, IEnumerable<string> roles);

        Task DeleteUserAsync(string userEmail);
        
        Task CreateUserAsync(CreateUser_VM model);
    }
}
