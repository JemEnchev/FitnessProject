namespace FitnessProject.Core.Services
{
    using FitnessProject.Core.Contracts;
    using FitnessProject.Core.Models;
    using FitnessProject.Infrastructure.Data.Models;
    using FitnessProject.Infrastructure.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SupplementBrandService : ISupplementBrandService
    {
        private readonly IApplicationDbRepository repo;

        public SupplementBrandService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task AddSupplementBrandAsync(AddSupplementBrand_VM model)
        {
            var brand = new SupplementBrand()
            {
                Name = model.Name,
                Description = model.Description,
            };

            if (repo.All<SupplementBrand>().FirstOrDefault(b => b.Name == model.Name) != null)
            {
                return;
            }

            await repo.AddAsync(brand);
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<BrandList_VM>> GetAllSupplementBrandsAsync()
        {
            return await repo.All<SupplementBrand>()
                .Select(b => new BrandList_VM()
                {
                    Name = b.Name,
                    Description = b.Description,                    
                })
                .ToListAsync();
        }

        public async Task<SupplementBrand> GetBrandByIdAsync(Guid brandId)
        {
            return await repo.All<SupplementBrand>()
                .FirstOrDefaultAsync(b => b.Id == brandId);
        }

        public async Task<SupplementBrand> GetBrandByNameAsync(string brandName)
        {
            return await repo.All<SupplementBrand>()
                .FirstOrDefaultAsync(b => b.Name == brandName);
        }

        public async Task RemoveSupplementBrandAsync(string brandName)
        {
            var brand = await GetBrandByNameAsync(brandName);

            if (brand != null)
            {
                try
                {
                    repo.Delete(brand);
                    await repo.SaveChangesAsync();
                }
                catch (Exception)
                {}
            }
        }
    }
}
