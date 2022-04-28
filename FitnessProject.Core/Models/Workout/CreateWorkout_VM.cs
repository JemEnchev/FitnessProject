namespace FitnessProject.Core.Models.Workout
{
    using System.ComponentModel.DataAnnotations;

    public class CreateWorkout_VM
    {
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}
