namespace FitnessProject.Core.Services
{
    using FitnessProject.Core.Contracts;
    using FitnessProject.Core.Models;
    using FitnessProject.Infrastructure.Data.Models;
    using FitnessProject.Infrastructure.Data.Repositories;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ExerciseService : IExerciseService
    {
        private readonly IApplicationDbRepository repo;

        private readonly IWebHostEnvironment webHostEnvironment;

        private readonly IUserManagerService userManagerService;

        public ExerciseService(
            IApplicationDbRepository _repo,
            IWebHostEnvironment _webHostEnvironment,
            IUserManagerService _userManagerService)
        {
            repo = _repo;
            webHostEnvironment = _webHostEnvironment;
            userManagerService = _userManagerService;
        }

        public async Task AddExerciseAsync(AddExercise_VM model)
        {
            string stringFileName = UploadFile(model);

            var exercise = new Exercise()
            {
                Name = model.Name,
                Category = model.Category,
                Description = model.Description,
                IsItBodyweight = model.IsItBodyweight,
                Requirements = model.Requirements,
                Difficulty = model.Difficulty,
                Image = stringFileName,
                Video = model.Video,
            };

            if (repo.All<Exercise>().FirstOrDefault(e => e.Name == exercise.Name) != null)
            {
                return;
            }

            await repo.AddAsync(exercise);
            await repo.SaveChangesAsync();
        }

        private string UploadFile(AddExercise_VM model)
        {
            string fileName = null;
            if (model.Image != null)
            {
                string uploadDir = Path.Combine(webHostEnvironment.WebRootPath, "img");
                fileName = Guid.NewGuid().ToString() + "-" + model.Image.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fileStream);
                }
            }
            return fileName;
        }

        public async Task<IEnumerable<Exercise_VM>> GetAllExercisesAsync()
        {
            return await repo.All<Exercise>()
                 .Select(e => new Exercise_VM()
                 {
                     Name = e.Name,
                     Category = e.Category,
                     Description = e.Description,
                     IsItBodyweight = e.IsItBodyweight,
                     Requirements = e.Requirements,
                     Difficulty = e.Difficulty,
                     Image = e.Image,
                     Video = e.Video,
                 })
                 .ToListAsync();
        }

        public async Task RemoveExerciseAsync(string exerciseName)
        {
            var exercise = await GetExerciseByNameAsync(exerciseName);

            var imagePath = Path.Combine(webHostEnvironment.WebRootPath, "img", exercise.Image);

            try
            {
                repo.Delete(exercise);
                await repo.SaveChangesAsync();

                File.Delete(imagePath);
            }
            catch (Exception)
            { }
        }

        public async Task<Exercise> GetExerciseByNameAsync(string exerciseName)
        {
            return await repo.All<Exercise>()
                //.Where(e => e.Name == exerciseName)
                //.Select(e => new Exercise_VM()
                //{
                //    Name = e.Name,
                //    Category = e.Category,
                //    Description = e.Description,
                //    IsItBodyweight = e.IsItBodyweight,
                //    Requirements = e.Requirements,
                //    Difficulty = e.Difficulty,
                //    Image = e.Image,
                //})
                .FirstOrDefaultAsync(e => e.Name == exerciseName);
        }

        public async Task AddToFavouritesAsync(string exerciseName, string userEmail)
        {
            var exercise = await GetExerciseByNameAsync(exerciseName);

            var user = await userManagerService.GetUserByEmailAsync(userEmail);

            if (exercise != null && user != null)
            {
                var userExercise = new UserExercise()
                {
                    User = user,
                    UserId = user.Id,
                    Exercise = exercise,
                    ExerciseId = exercise.Id
                };

                if (!repo.All<UserExercise>().Contains(userExercise))
                {
                    try
                    {
                        await repo.AddAsync(userExercise);
                        await repo.SaveChangesAsync();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        public async Task<IEnumerable<Exercise_VM>> GetAllFavouritesAsync(string userEmail)
        {
            var user = await userManagerService.GetUserByEmailAsync(userEmail);

            return await repo.All<UserExercise>()
                .Where(u => u.User.Email == userEmail)
                .Select(e => new Exercise_VM()
                {
                    Name = e.Exercise.Name,
                    Category = e.Exercise.Category,
                    IsItBodyweight = e.Exercise.IsItBodyweight,
                    Requirements = e.Exercise.Requirements,
                    Difficulty = e.Exercise.Difficulty,
                    Description = e.Exercise.Description,
                    Image = e.Exercise.Image,
                    Video = e.Exercise.Video
                })
                .ToListAsync();
        }

        public async Task RemoveFromFavouritesAsync(string exerciseName, string userEmail)
        {
            var exercise = await GetExerciseByNameAsync(exerciseName);

            var user = await userManagerService.GetUserByEmailAsync(userEmail);

            if (exercise != null && user != null)
            {
                var userExercise = new UserExercise()
                {
                    UserId = user.Id,
                    User = user,
                    ExerciseId = exercise.Id,
                    Exercise = exercise,
                };

                repo.Delete(userExercise);
                await repo.SaveChangesAsync();
            }
        }
    }
}
