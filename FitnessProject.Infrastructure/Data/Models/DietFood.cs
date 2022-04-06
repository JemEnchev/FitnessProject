namespace FitnessProject.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    #nullable disable

    public class DietFood
    {
        public Guid DietId { get; set; }

        [ForeignKey(nameof(DietId))]
        public Diet Diet { get; set; }



        public Guid FoodId { get; set; }

        [ForeignKey(nameof(FoodId))]
        public Food Food { get; set; }
    }
}
