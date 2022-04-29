namespace FitnessProject.Core.Models
{
    using FitnessProject.Infrastructure.Data.Models;
    using FitnessProject.Infrastructure.Data.Models.Enums;
    using FitnessProject.Infrastructure.Data.Repositories;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.ComponentModel.DataAnnotations;

    public class AddSupplement_VM
    {
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "{0} must be between {1} and {2}")]
        public double Weight { get; set; }

        [Required]
        public SupplementType Type { get; set; }

        [Required]
        public Guid BrandId { get; set; }

        [Required]
        public Guid FlavourId { get; set; }
    }
}
