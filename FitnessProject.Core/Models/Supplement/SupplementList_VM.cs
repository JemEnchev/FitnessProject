namespace FitnessProject.Core.Models.Supplement
{
    using FitnessProject.Infrastructure.Data.Models.Enums;

    public class SupplementList_VM
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public double Weight { get; set; }

        public SupplementType Type { get; set; }

        public string BrandName { get; set; }

        public string FlavourName { get; set; }
    }
}
