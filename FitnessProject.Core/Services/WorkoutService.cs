namespace FitnessProject.Core.Services
{
    using FitnessProject.Core.Contracts;
    using FitnessProject.Core.Models.Workout;
    using FitnessProject.Infrastructure.Data.Models;
    using FitnessProject.Infrastructure.Data.Repositories;
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class WorkoutService : IWorkoutService
    {
        private readonly IApplicationDbRepository repo;

        private readonly IUserManagerService userManagerService;


        public WorkoutService(
            IApplicationDbRepository _repo,
            IUserManagerService _userManagerService)
        {
            repo = _repo;
            userManagerService = _userManagerService;
        }


        public async Task CreateWorkoutAsync(CreateWorkout_VM model, string userId)
        {
            var workout = new Workout()
            {
                Name = model.Name,
                Description = model.Description,
                UserId = userId
            };

            if (repo.All<Workout>().FirstOrDefault(w => w.Name == model.Name) != null)
            {
                return;
            }

            await repo.AddAsync(workout);
            await repo.SaveChangesAsync();
        }

        public Task<IEnumerable<Workout_VM>> GetAllWorkoutsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
