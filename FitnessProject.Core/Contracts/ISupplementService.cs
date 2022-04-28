namespace FitnessProject.Core.Contracts
{
    using FitnessProject.Core.Models;
    using FitnessProject.Core.Models.Supplement;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface ISupplementService
    {
        Task<IEnumerable<SupplementList_VM>> GetAllSupplementsAsync();

        Task<IEnumerable<SupplementList_VM>> GetAllFavouritesAsync(string userEmail);

        Task AddSupplementAsync(AddSupplement_VM model);

        Task RemoveSupplementAsync(Guid supplementId);

        Task<ICollection<SelectListItem>> PopulateBrandsAsync();

        Task<ICollection<SelectListItem>> PopulateFlavourssAsync();

        Task AddToFavouritesAsync(Guid supplementId, string userEmail);

        Task RemoveFromFavouritesAsync(Guid supplementId, string userEmail);
    }
}
