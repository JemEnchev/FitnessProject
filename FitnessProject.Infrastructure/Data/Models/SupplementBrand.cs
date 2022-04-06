namespace FitnessProject.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    #nullable disable

    public class SupplementBrand
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}
