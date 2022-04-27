namespace FitnessProject.Core.Models
{
    using FitnessProject.Infrastructure.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    public class AddFood_VM
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} must be between {1} and {2} characters")]
        public string Name { get; set; }

        [Required]
        public FoodType Type { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [Range(0, 10000, ErrorMessage = "{0} must be between {1} and {2}")]
        public ushort CaloriesPer100 { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "{0} must be between {1} and {2}")]
        public byte ProteinPer100 { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "{0} must be between {1} and {2}")]
        public byte CarbsPer100 { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "{0} must be between {1} and {2}")]
        public byte FatPer100 { get; set; }
    }
}
