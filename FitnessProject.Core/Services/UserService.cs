namespace FitnessProject.Core.Services
{
    using FitnessProject.Core.Contracts;
    using FitnessProject.Core.Models;
    using FitnessProject.Infrastructure.Data.Identity;
    using FitnessProject.Infrastructure.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly IApplicationDbRepository repo;

        public UserService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }


        public async Task<IEnumerable<UserList_VM>> GetUsersAsync()
        {
            return await repo.All<ApplicationUser>()
                .Select(u => new UserList_VM()
                {
                    Id = u.Id,
                    Name = $"{u.FirstName} {u.LastName}",
                    Email = u.Email
                })
                .ToListAsync();
        }
    }
}
