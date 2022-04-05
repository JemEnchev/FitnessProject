﻿namespace FitnessProject.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Food
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [Range(0, 10000)]
        public ushort CaloriesPer100 { get; set; }

        [Required]
        [Range(0, 100)]
        public byte ProteinPer100 { get; set; }

        [Required]
        [Range(0, 100)]
        public byte CarbsPer100 { get; set; }

        [Required]
        [Range(0, 100)]
        public byte FatPer100 { get; set; }


        public ICollection<DietFood> DietFoods { get; set; }
    }
}