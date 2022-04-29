namespace FitnessProject.Infrastructure.Data.Models
{
    using FitnessProject.Infrastructure.Data.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    #nullable disable

    public class Diet
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(500)]
        public string Breakfast { get; set; }

        [Required]
        [StringLength(500)]
        public string Lunch { get; set; }

        [Required]
        [StringLength(500)]
        public string Dinner { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }


        public ICollection<DietFood> DietFoods { get; set; } = new List<DietFood>();
        
        public ICollection<DietSupplement> DietSupplements { get; set; } = new List<DietSupplement>();

    }
}
