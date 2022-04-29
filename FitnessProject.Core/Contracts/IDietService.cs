namespace FitnessProject.Core.Contracts
{
    using FitnessProject.Core.Models.Diet;
    using FitnessProject.Infrastructure.Data.Models;

    public interface IDietService
    {
        Task<IEnumerable<Diet_VM>> GetAllDietsAsync(string userEmail);

        Task CreateDietAsync(Diet_VM model, string userId);

        Task DeleteDietAsync(string dietName);

        Task<Diet> GetDietByNameAsync(string dietName);

        //Task<ICollection<SelectListItem>> PopulateDietsAsync();

        //Task AddFoodToDiet(DietFood_VM model);

        //Task AddSupplementToDiet(DietSupplement_VM model);

        //Task<Diet> GetDietByIdAsync(string dietId);
    }
}
