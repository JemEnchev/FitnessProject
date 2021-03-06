namespace FitnessProject.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    #nullable disable

    public class DietSupplement
    {
        [Required]
        public Guid DietId { get; set; }

        [ForeignKey(nameof(DietId))]
        public Diet Diet { get; set; }


        [Required]
        public Guid SupplementId { get; set; }

        [ForeignKey(nameof(SupplementId))]
        public Supplement Supplement { get; set; }
    }
}
