namespace FitnessProject.Infrastructure.Data.Identity
{
    using FitnessProject.Infrastructure.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }


        public ICollection<Workout> Workouts { get; set; } = new List<Workout>();

        public ICollection<Diet> Diets { get; set; } = new List<Diet>();
    }
}
