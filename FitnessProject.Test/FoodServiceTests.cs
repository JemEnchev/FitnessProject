namespace FitnessProject.Test
{
    using FitnessProject.Core.Contracts;
    using FitnessProject.Core.Models;
    using FitnessProject.Core.Services;
    using FitnessProject.Infrastructure.Data.Identity;
    using FitnessProject.Infrastructure.Data.Models;
    using FitnessProject.Infrastructure.Data.Models.Enums;
    using FitnessProject.Infrastructure.Data.Repositories;
    using Microsoft.Extensions.DependencyInjection;
    using NUnit.Framework;
    using System;
    using System.Threading.Tasks;

    public class Tests
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;

        [SetUp]
        public async Task Setup()
        {
            dbContext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IApplicationDbRepository, ApplicationDbRepository>()
                .AddSingleton<IFoodService, FoodService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IApplicationDbRepository>();
            await SeedDbAsync(repo);
        }

        [Test]
        public void AddingExistringFoodShouldThrow()
        {
            var foodId = Guid.NewGuid();

            var food = new Food()
            {
                Id = foodId,
                Name = "Apple",
                Type = FoodType.Fruits,
                CaloriesPer100 = 100,
                ProteinPer100 = 1,
                CarbsPer100 = 30,
                FatPer100 = 1,
            };

            var foodVM = new AddFood_VM()
            {
                Name = food.Name,
                Type = food.Type,
                CaloriesPer100= food.CaloriesPer100,
                ProteinPer100= food.ProteinPer100,
                CarbsPer100= food.CarbsPer100,
                FatPer100 = food.FatPer100,
            };

            var service = serviceProvider.GetService<IFoodService>();

            Assert.CatchAsync<ArgumentException>(async () => await service.AddFoodAsync(foodVM), "Food already exists!");
        }

        [Test]
        public void AddingExistingFoodToFavouritesShouldThrow()
        {

            var service = serviceProvider.GetService<IFoodService>();

            Assert.CatchAsync<ArgumentException>(async () => await service.AddToFavouritesAsync("Apple", "gosho@gosho.com"), "Food already added!");
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private async Task SeedDbAsync(IApplicationDbRepository repo)
        {
            var user = new ApplicationUser()
            {
                Id = "123456",
                UserName = "Gosho",
                Email = "gosho@gosho.com",
                EmailConfirmed = true,
                FirstName = "Gosho",
                LastName = "Goshev",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
            };


            var food = new Food()
            {
                Id = Guid.NewGuid(),
                Name = "Apple",
                Type = FoodType.Fruits,
                CaloriesPer100 = 100,
                ProteinPer100 = 1,
                CarbsPer100 = 30,
                FatPer100 = 1,
            };

            var userFood = new UserFood()
            {
                UserId = user.Id,
                FoodId = food.Id,
            };


            await repo.AddAsync(user);
            await repo.AddAsync(food);
            await repo.AddAsync(userFood);
            await repo.SaveChangesAsync();
        }
    }
}