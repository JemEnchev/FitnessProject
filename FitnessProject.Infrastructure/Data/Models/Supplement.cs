namespace FitnessProject.Infrastructure.Data.Models
{
    using FitnessProject.Infrastructure.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    #nullable disable

    public class Supplement
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }


        [Required]
        public Guid BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public SupplementBrand Brand { get; set; }


        [Required]
        [Range(0, 10)]
        public double Weight { get; set; }

        [Required]
        [StringLength(50)]
        public SupplementType Type { get; set; }


        [Required]
        public Guid FlavourId { get; set; }

        [ForeignKey(nameof(FlavourId))]
        public SupplementFlavour Flavour { get; set; }


        public ICollection<DietSupplement> DietSupplements { get; set; }

    }
}
