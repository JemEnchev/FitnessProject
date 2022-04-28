namespace FitnessProject.Core.Contracts
{
    using FitnessProject.Core.Models;
    using FitnessProject.Infrastructure.Data.Models;

    public interface ISupplementFlavourService
    {
        Task<IEnumerable<FlavourList_VM>> GetAllSupplementFlavoursAsync();

        Task AddSupplementFlavourAsync(AddFlavour_VM model);

        Task RemoveSupplementFlavourAsync(string flavourName);

        Task<SupplementFlavour> GetFlavourByNameAsync(string flavourName);

        Task<SupplementFlavour> GetFlavourByIdAsync(Guid flavourId);
    }
}
