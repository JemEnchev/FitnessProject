namespace FitnessProject.Core.Services
{
    using FitnessProject.Core.Contracts;
    using FitnessProject.Core.Models;
    using FitnessProject.Core.Models.Supplement;
    using FitnessProject.Infrastructure.Data.Models;
    using FitnessProject.Infrastructure.Data.Repositories;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SupplementService : ISupplementService
    {
        private readonly IApplicationDbRepository repo;

        private readonly IUserManagerService userManagerService;

        private readonly ISupplementBrandService supplementBrandService;

        private readonly ISupplementFlavourService supplementFlavourService;


        public SupplementService(
            IApplicationDbRepository _repo,
            IUserManagerService _userManagerService,
            ISupplementBrandService _supplementBrandService,
            ISupplementFlavourService _supplementFlavourService)
        {
            repo = _repo;
            userManagerService = _userManagerService;
            supplementBrandService = _supplementBrandService;
            supplementFlavourService = _supplementFlavourService;
        }


        public async Task AddSupplementAsync(AddSupplement_VM model)
        {
            var supplement = new Supplement()
            {
                Name = model.Name,
                Description = model.Description,
                Weight = model.Weight,
                Type = model.Type,
                Brand = await supplementBrandService.GetBrandByIdAsync(model.BrandId),
                Flavour = await supplementFlavourService.GetFlavourByIdAsync(model.FlavourId),
            };

            if (await repo.All<Supplement>().FirstOrDefaultAsync(s =>
                s.Name == supplement.Name &&
                s.Description == supplement.Description &&
                s.Weight == supplement.Weight &&
                s.Type == supplement.Type &&
                s.Brand == supplement.Brand &&
                s.Flavour == supplement.Flavour) != null)
            {
                throw new ArgumentException("Supplement already exists!");
            }

            await repo.AddAsync(supplement);
            await repo.SaveChangesAsync();
        }

        public async Task AddToFavouritesAsync(Guid supplementId, string userEmail)
        {
            var supplement = await GetSupplementByIdAsync(supplementId);

            var user = await userManagerService.GetUserByEmailAsync(userEmail);

            if (supplement != null && user != null)
            {
                var userSupplement = new UserSupplement()
                {
                    User = user,
                    UserId = user.Id,
                    Supplement = supplement,
                    SupplementId = supplement.Id,
                };

                if (!repo.All<UserSupplement>().Contains(userSupplement))
                {
                        await repo.AddAsync(userSupplement);
                        await repo.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException("Supplement already added to favourites!");
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public async Task<IEnumerable<SupplementList_VM>> GetAllFavouritesAsync(string userEmail)
        {
            var user = await userManagerService.GetUserByEmailAsync(userEmail);

            return await repo.All<UserSupplement>()
                .Where(u => u.User.Email == userEmail)
                .Select(s => new SupplementList_VM()
                {
                    Id = s.Supplement.Id,
                    Name = s.Supplement.Name,
                    Description = s.Supplement.Description,
                    Weight = s.Supplement.Weight,
                    Type = s.Supplement.Type,
                    BrandName = s.Supplement.Brand.Name,
                    FlavourName = s.Supplement.Flavour.Name,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<SupplementList_VM>> GetAllSupplementsAsync()
        {
            return await repo.All<Supplement>()
                 .Select(s => new SupplementList_VM()
                 {
                     Id = s.Id,
                     Name = s.Name,
                     Description = s.Description,
                     Weight = s.Weight,
                     Type = s.Type,
                     BrandName = s.Brand.Name,
                     FlavourName = s.Flavour.Name,
                 })
                 .ToListAsync();
        }

        public async Task<ICollection<SelectListItem>> PopulateBrandsAsync()
        {
            return await repo.All<SupplementBrand>()
                .Select(s => new SelectListItem()
                {
                    Value = s.Id.ToString(),
                    Text = s.Name,
                })
                .ToListAsync();
        }

        public async Task<ICollection<SelectListItem>> PopulateFlavourssAsync()
        {
            return await repo.All<SupplementFlavour>()
                .Select(s => new SelectListItem()
                {
                    Value = s.Id.ToString(),
                    Text = s.Name,
                })
                .ToListAsync();
        }

        public async Task RemoveFromFavouritesAsync(Guid supplementId, string userEmail)
        {
            var supplement = await GetSupplementByIdAsync(supplementId);

            var user = await userManagerService.GetUserByEmailAsync(userEmail);

            if (supplement != null && user != null)
            {
                var userSupplement = new UserSupplement()
                {
                    UserId = user.Id,
                    User = user,
                    SupplementId = supplement.Id,
                    Supplement = supplement,
                };

                repo.Delete(userSupplement);
                await repo.SaveChangesAsync();
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public async Task RemoveSupplementAsync(Guid supplementId)
        {
            var supplement = await GetSupplementByIdAsync(supplementId);

            repo.Delete(supplement);
            await repo.SaveChangesAsync();
        }

        private async Task<Supplement> GetSupplementByIdAsync(Guid supplementId)
        {
            return await repo.GetByIdAsync<Supplement>(supplementId);
        }
    }
}
