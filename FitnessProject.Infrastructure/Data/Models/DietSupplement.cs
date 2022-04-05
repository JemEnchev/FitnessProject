namespace FitnessProject.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class DietSupplement
    {
        public Guid DietId { get; set; }

        [ForeignKey(nameof(DietId))]
        public Diet Diet { get; set; }



        public Guid SupplementId { get; set; }

        [ForeignKey(nameof(SupplementId))]
        public Supplement Supplement { get; set; }
    }
}
