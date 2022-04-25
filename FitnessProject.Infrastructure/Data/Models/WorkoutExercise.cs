namespace FitnessProject.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    #nullable disable

    public class WorkoutExercise
    {
        [Required]
        public Guid WorkoutId { get; set; }

        [ForeignKey(nameof(WorkoutId))]
        public Workout Workout { get; set; }


        [Required]
        public Guid ExerciseId { get; set; }

        [ForeignKey(nameof(ExerciseId))]
        public Exercise Exercise { get; set; }
    }
}
