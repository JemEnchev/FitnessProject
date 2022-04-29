namespace FitnessProject.Core.Models.Diet
{
    using System.ComponentModel.DataAnnotations;

    public class Diet_VM
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Breakfast { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Lunch { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Dinner { get; set; }
    }
}
