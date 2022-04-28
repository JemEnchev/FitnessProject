namespace FitnessProject.Core.Models.Workout
{
    using FitnessProject.Infrastructure.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class Workout_VM
    {
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }


        public string? UserId { get; set; }

        public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();

    }
}
