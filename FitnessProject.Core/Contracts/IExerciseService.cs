namespace FitnessProject.Core.Contracts
{
    using FitnessProject.Core.Models;
    using FitnessProject.Infrastructure.Data.Models;

    public interface IExerciseService
    {
        Task<IEnumerable<Exercise>> GetAllExercisesAsync();

        Task<IEnumerable<Exercise>> GetAllFavouritesAsync(string userEmail);

        Task AddExerciseAsync(AddExercise_VM model);

        Task RemoveExerciseAsync(string exerciseName);

        Task AddToFavouritesAsync(string exerciseName, string userEmail);

        Task RemoveFromFavouritesAsync(string exerciseName, string userEmail);
    }
}
