namespace FitnessProject.Core.Models
{
    using FitnessProject.Infrastructure.Data.Models.Enums;

    public class FoodList_VM
    {
        public string Name { get; set; }

        public FoodType Type { get; set; }

        public string Description { get; set; }

        public ushort CaloriesPer100 { get; set; }

        public byte ProteinPer100 { get; set; }

        public byte CarbsPer100 { get; set; }

        public byte FatPer100 { get; set; }
    }
}
