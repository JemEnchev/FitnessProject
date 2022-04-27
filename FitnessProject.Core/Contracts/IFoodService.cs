namespace FitnessProject.Core.Contracts
{
    using FitnessProject.Core.Models;
    using FitnessProject.Infrastructure.Data.Identity;
    using FitnessProject.Infrastructure.Data.Models;

    public interface IFoodService
    {
        Task<IEnumerable<FoodList_VM>> GetAllFoodAsync();

        Task<IEnumerable<FoodList_VM>> GetAllFavouritesAsync(string userEmail);

        Task AddFoodAsync(AddFood_VM model);

        Task RemoveFoodAsync(string foodName);

        Task AddToFavouritesAsync(string foodName, string userEmail);
        
        Task RemoveFromFavouritesAsync(string foodName, string userEmail);
    }
}
