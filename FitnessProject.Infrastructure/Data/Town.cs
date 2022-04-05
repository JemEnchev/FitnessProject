namespace FitnessProject.Infrastructure.Data
{
    using System.ComponentModel.DataAnnotations;

    public class Town
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        public ICollection<Address> addresses { get; set; } = new List<Address>();
    }
}
