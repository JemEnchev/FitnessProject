namespace FitnessProject.Infrastructure.Data.Models
{
    using FitnessProject.Infrastructure.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    #nullable disable

    public class Exercise
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public ExerciseCategory Category { get; set; }

        [Required]
        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public bool IsItBodyweight { get; set; }

        [StringLength(500)]
        public string? Requirements { get; set; }

        [Required]
        public ExerciseDifficulty Difficulty { get; set; }


        public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();

        public ICollection<UserExercise> UserExercises { get; set; } = new List<UserExercise>();
    }
}
