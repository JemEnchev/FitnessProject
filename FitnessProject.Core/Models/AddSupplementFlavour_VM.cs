namespace FitnessProject.Core.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AddSupplementFlavour_VM
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} must be between {1} and {2} characters")]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}
