﻿namespace FitnessProject.Core.Services
{
    using FitnessProject.Core.Contracts;
    using FitnessProject.Core.Models;
    using FitnessProject.Infrastructure.Data.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UserManagerService : IUserManagerService
    {
        private readonly UserManager<ApplicationUser> userManager;

        private readonly RoleManager<IdentityRole> roleManager;

        public UserManagerService(UserManager<ApplicationUser> _userManager,
            RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;
        }


        public async Task<IEnumerable<UserRoles_VM>> GetUsersAsync()
        {
            var users = await userManager.Users.ToListAsync();
            var userRolesViewModel = new List<UserRoles_VM>();
            foreach (ApplicationUser user in users)
            {
                var thisViewModel = new UserRoles_VM();
                thisViewModel.UserId = user.Id;
                thisViewModel.Email = user.Email;
                thisViewModel.FirstName = user.FirstName;
                thisViewModel.LastName = user.LastName;
                thisViewModel.Roles = await GetUserRolesAsync(user);
                userRolesViewModel.Add(thisViewModel);
            }
            return userRolesViewModel;
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync(ApplicationUser user)
        {
            return new List<string>(await userManager.GetRolesAsync(user));
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            return await userManager.FindByIdAsync(userId);
        }

        public async Task<IEnumerable<ManageUserRoles_VM>> ManageUserRolesAsync(ApplicationUser user)
        {
            var roles = new List<ManageUserRoles_VM>();
            foreach (var role in roleManager.Roles)
            {
                var userRolesViewModel = new ManageUserRoles_VM
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                roles.Add(userRolesViewModel);
            }
            return roles;
        }

        public async Task<IdentityResult> AddRolesAsync(ApplicationUser user, IEnumerable<ManageUserRoles_VM> model)
        {
            return await userManager.AddToRolesAsync(user, model
                .Where(x => x.Selected)
                .Select(y => y.RoleName));
        }

        public async Task<IdentityResult> RemoveRolesAsync(ApplicationUser user, IEnumerable<string> roles)
        {
            return await userManager.RemoveFromRolesAsync(user, roles);
        }

        public async Task DeleteUser(string userEmail)
        {
            var user = userManager.Users
                .FirstOrDefault(u => u.Email == userEmail);
            if (user != null)
            await userManager.DeleteAsync(user);
        }

        public Task<ApplicationUser> CreateUser()
        {
            throw new NotImplementedException();
        }
    }
}