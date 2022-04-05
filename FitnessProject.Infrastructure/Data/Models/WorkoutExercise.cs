namespace FitnessProject.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class WorkoutExercise
    {

        public Guid WorkoutId { get; set; }

        [ForeignKey(nameof(WorkoutId))]
        public Workout Workout { get; set; }



        public Guid ExerciseId { get; set; }

        [ForeignKey(nameof(ExerciseId))]
        public Exercise Exercise { get; set; }
    }
}
