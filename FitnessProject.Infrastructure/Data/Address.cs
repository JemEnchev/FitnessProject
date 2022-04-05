namespace FitnessProject.Infrastructure.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Address
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(250)]
        public string Text { get; set; }

        public Guid TownId { get; set; }

        [ForeignKey(nameof(TownId))]
        public Town Town { get; set; }
    }
}
