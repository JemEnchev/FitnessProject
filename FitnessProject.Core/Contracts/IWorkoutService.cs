namespace FitnessProject.Core.Contracts
{
    using FitnessProject.Core.Models.Workout;
    using FitnessProject.Infrastructure.Data.Models;

    public interface IWorkoutService
    {
        Task<IEnumerable<Workout_VM>> GetAllWorkoutsAsync();

        Task CreateWorkoutAsync(CreateWorkout_VM model, string userid);

        //Task RemoveWorkoutAsync(string workoutName);

        //Task<Workout> GetBrandByNameAsync(string workoutName);

        //Task<Workout> GetBrandByIdAsync(Guid workoutId);
    }
}
