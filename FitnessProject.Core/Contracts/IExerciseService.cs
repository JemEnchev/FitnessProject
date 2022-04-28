namespace FitnessProject.Core.Contracts
{
    using FitnessProject.Core.Models;
    using FitnessProject.Infrastructure.Data.Models;

    public interface IExerciseService
    {
        Task<IEnumerable<Exercise_VM>> GetAllExercisesAsync();

        Task<IEnumerable<Exercise_VM>> GetAllFavouritesAsync(string userEmail);

        Task AddExerciseAsync(AddExercise_VM model);

        Task RemoveExerciseAsync(string exerciseName);
        
        Task<Exercise> GetExerciseByNameAsync(string exerciseName);

        Task AddToFavouritesAsync(string exerciseName, string userEmail);

        Task RemoveFromFavouritesAsync(string exerciseName, string userEmail);
    }
}
