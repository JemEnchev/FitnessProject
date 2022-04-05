﻿namespace FitnessProject.Infrastructure.Data.Models
{
    using FitnessProject.Infrastructure.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    public class Exercise
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public bool IsItBodyweight { get; set; }

        [StringLength(500)]
        public string? Requirements { get; set; }

        [Required]
        public ExerciseDifficulty Difficulty { get; set; }


        public ICollection<WorkoutExercise> WorkoutExercises { get; set; }
    }
}
