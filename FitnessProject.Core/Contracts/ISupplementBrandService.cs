namespace FitnessProject.Core.Contracts
{
    using FitnessProject.Core.Models;
    using FitnessProject.Infrastructure.Data.Models;

    public interface ISupplementBrandService
    {
        Task<IEnumerable<BrandList_VM>> GetAllSupplementBrandsAsync();

        Task AddSupplementBrandAsync(AddSupplementBrand_VM model);

        Task RemoveSupplementBrandAsync(string brandName);

        Task<SupplementBrand> GetBrandByNameAsync(string brandName);

        Task<SupplementBrand> GetBrandByIdAsync(Guid brandId);
    }
}
