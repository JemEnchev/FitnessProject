namespace FitnessProject.Core.Models
{
    using FitnessProject.Infrastructure.Data.Models.Enums;
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class AddExercise_VM
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} characters")]
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

        [Required]
        public IFormFile Image { get; set; }

        public string? Video { get; set; }
    }
}
