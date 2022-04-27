namespace FitnessProject.Core.Services
{
    using FitnessProject.Core.Contracts;
    using FitnessProject.Core.Models;
    using FitnessProject.Infrastructure.Data.Models;
    using FitnessProject.Infrastructure.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SupplementFlavourService : ISupplementFlavourService
    {
        private readonly IApplicationDbRepository repo;

        public SupplementFlavourService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task AddSupplementFlavourAsync(AddSupplementFlavour_VM model)
        {
            var flavour = new SupplementFlavour()
            {
                Name = model.Name,
                Description = model.Description,
            };

            if (repo.All<SupplementFlavour>().FirstOrDefault(b => b.Name == model.Name) != null)
            {
                return;
            }

            await repo.AddAsync(flavour);
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<FlavourList_VM>> GetAllSupplementFlavoursAsync()
        {
            return await repo.All<SupplementFlavour>()
                .Select(f => new FlavourList_VM()
                {
                    Name = f.Name,
                    Description = f.Description,
                })
                .ToListAsync();
        }

        public async Task<SupplementFlavour> GetFlavourByNameAsync(string flavourName)
        {
            return await repo.All<SupplementFlavour>()
                .FirstOrDefaultAsync(f => f.Name == flavourName);
        }

        public async Task RemoveSupplementFlavourAsync(string flavourName)
        {
            var flavour = await GetFlavourByNameAsync(flavourName);

            if (flavour != null)
            {
                try
                {
                    repo.Delete(flavour);
                    await repo.SaveChangesAsync();
                }
                catch (Exception)
                { }
            }
        }
    }
}
