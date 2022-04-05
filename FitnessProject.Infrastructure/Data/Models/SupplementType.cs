namespace FitnessProject.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SupplementType
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string? Type { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}
