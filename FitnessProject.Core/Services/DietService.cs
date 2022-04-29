namespace FitnessProject.Core.Services
{
    using FitnessProject.Core.Contracts;
    using FitnessProject.Core.Models.Diet;
    using FitnessProject.Infrastructure.Data.Models;
    using FitnessProject.Infrastructure.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class DietService : IDietService
    {
        private readonly IApplicationDbRepository repo;

        private readonly IUserManagerService userManagerService;

        public DietService(
            IApplicationDbRepository _repo,
            IUserManagerService _userManagerService)
        {
            repo = _repo;
            userManagerService = _userManagerService;
        }


        public async Task CreateDietAsync(Diet_VM model, string userId)
        {
            var diet = new Diet()
            {
                Name = model.Name,
                Description = model.Description,
                Breakfast = model.Breakfast,
                Lunch = model.Lunch,
                Dinner = model.Dinner,
            };

            var user = await userManagerService.GetUserByIdAsync(userId);

            user.Diets.Add(diet);

            if (repo.All<Diet>().FirstOrDefault(d => d.Name == model.Name) != null)
            {
                throw new ArgumentException("Diet already exists!");
            }

            await repo.AddAsync(diet);
            await repo.SaveChangesAsync();
        }

        public async Task DeleteDietAsync(string dietName)
        {
            var diet = await GetDietByNameAsync(dietName);

            if (diet != null)
            {
                repo.Delete(diet);
                await repo.SaveChangesAsync();
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public async Task<IEnumerable<Diet_VM>> GetAllDietsAsync(string userEmail)
        {
            var user = await userManagerService.GetUserByEmailAsync(userEmail);

            return await repo.All<Diet>()
                .Where(d => d.User == user)
                .Select(d => new Diet_VM()
                {
                    Name = d.Name,
                    Description = d.Description,
                    Breakfast = d.Breakfast,
                    Lunch = d.Lunch,
                    Dinner = d.Dinner,
                })
                .ToListAsync();
        }

        public async Task<Diet> GetDietByNameAsync(string dietName)
        {
            return await repo.All<Diet>()
                .FirstOrDefaultAsync(d => d.Name == dietName);
        }
    }
}
