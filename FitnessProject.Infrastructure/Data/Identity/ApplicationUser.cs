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


        public ICollection<Diet> Diets { get; set; } = new List<Diet>();

        public ICollection<UserExercise> FavouriteExercises { get; set; } = new List<UserExercise>();

        public ICollection<UserFood> FavouriteFoods { get; set; } = new List<UserFood>();

        public ICollection<UserSupplement> FavouriteSupplements { get; set; } = new List<UserSupplement>();
    }
}
