namespace FitnessProject.Core.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AddSupplementBrand_VM
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}
