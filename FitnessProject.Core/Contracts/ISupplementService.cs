namespace FitnessProject.Core.Contracts
{
    public interface ISupplementService
    {
        //Task<IEnumerable<SupplementList_VM>> GetAllSupplementsAsync();

        //Task<IEnumerable<SupplementList_VM>> GetAllFavouritesAsync(string userEmail);

        //Task AddSupplementAsync(AddSupplement_VM model);

        Task AddToFavouritesAsync(string supName, string userEmail);

        Task RemoveFromFavouritesAsync(string supName, string userEmail);
    }
}
