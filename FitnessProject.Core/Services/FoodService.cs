namespace FitnessProject.Core.Services
{
    using FitnessProject.Core.Contracts;
    using FitnessProject.Core.Models;
    using FitnessProject.Infrastructure.Data.Identity;
    using FitnessProject.Infrastructure.Data.Models;
    using FitnessProject.Infrastructure.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class FoodService : IFoodService
    {
        private readonly IApplicationDbRepository repo;

        private readonly IUserManagerService userManagerService;

        public FoodService(
            IApplicationDbRepository _repo,
            IUserManagerService _userManagerService)
        {
            repo = _repo;
            userManagerService = _userManagerService;
        }

        public async Task AddFoodAsync(AddFood_VM model)
        {
            var food = new Food()
            {
                Name = model.Name,
                Type = model.Type,
                Description = model.Description,
                CaloriesPer100 = model.CaloriesPer100,
                ProteinPer100 = model.ProteinPer100,
                CarbsPer100 = model.CarbsPer100,
                FatPer100 = model.FatPer100,
            };

            if (repo.All<Food>().FirstOrDefault(f => f.Name == food.Name) != null)
            {
                return;
            }

            await repo.AddAsync(food);
            await repo.SaveChangesAsync();
        }

        public async Task AddToFavouritesAsync(string foodName, string userEmail)
        {
            var food = await GetFoodByNameAsync(foodName);

            var user = await userManagerService.GetUserByEmailAsync(userEmail);

            if (food != null && user != null)
            {
                var userFood = new UserFood()
                {
                    User = user,
                    UserId = user.Id,
                    Food = food,
                    FoodId = food.Id,
                };

                if (!repo.All<UserFood>().Contains(userFood))
                {
                    try
                    {
                        await repo.AddAsync(userFood);
                        await repo.SaveChangesAsync();
                    }
                    catch (Exception)
                    {}
                }
            }
        }

        public async Task<IEnumerable<FoodList_VM>> GetAllFavouritesAsync(string userEmail)
        {
            var user = await userManagerService.GetUserByEmailAsync(userEmail);

            return await repo.All<UserFood>()
                .Where(u => u.User.Email == userEmail)
                .Select(f => new FoodList_VM()
                {
                    Name = f.Food.Name,
                    Type = f.Food.Type,
                    Description = f.Food.Description,
                    CaloriesPer100 = f.Food.CaloriesPer100,
                    ProteinPer100 = f.Food.ProteinPer100,
                    CarbsPer100 = f.Food.CarbsPer100,
                    FatPer100 = f.Food.FatPer100,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<FoodList_VM>> GetAllFoodAsync()
        {
            return await repo.All<Food>()
                 .Select(f => new FoodList_VM()
                 {
                     Name = f.Name,
                     Type = f.Type,
                     Description = f.Description,
                     CaloriesPer100 = f.CaloriesPer100,
                     ProteinPer100 = f.ProteinPer100,
                     CarbsPer100 = f.CarbsPer100,
                     FatPer100 = f.FatPer100,
                 })
                 .ToListAsync();
        }

        public async Task RemoveFoodAsync(string foodName)
        {
            var food = await GetFoodByNameAsync(foodName);

            try
            {
                repo.Delete(food);
                await repo.SaveChangesAsync();
            }
            catch (Exception)
            {}
        }

        public async Task RemoveFromFavouritesAsync(string foodName, string userEmail)
        {
            var food = await GetFoodByNameAsync(foodName);

            var user = await userManagerService.GetUserByEmailAsync(userEmail);

            if (food != null && user != null)
            {
                var userFood = new UserFood()
                {
                    UserId = user.Id,
                    User = user,
                    FoodId = food.Id,
                    Food = food,
                };
                
                repo.Delete(userFood);
                await repo.SaveChangesAsync();
            }
        }

        private async Task<Food> GetFoodByNameAsync(string name)
        {
            return await repo.All<Food>()
                .FirstOrDefaultAsync(f => f.Name == name);
        }
    }
}
