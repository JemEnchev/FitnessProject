namespace FitnessProject.Infrastructure.Data
{
    using FitnessProject.Infrastructure.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SupplementBrand>()
               .HasIndex(b => b.Name)
               .IsUnique();
            
            modelBuilder.Entity<SupplementFlavour>()
               .HasIndex(f => f.Name)
               .IsUnique(); 
            
            modelBuilder.Entity<Supplement>()
               .HasIndex(s => s.Name)
               .IsUnique();

            modelBuilder.Entity<Exercise>()
               .HasIndex(e => e.Name)
               .IsUnique();

            modelBuilder.Entity<Food>()
               .HasIndex(f => f.Name)
               .IsUnique();



            modelBuilder.Entity<WorkoutExercise>()
                .HasKey(we => new { we.ExerciseId, we.WorkoutId });

            modelBuilder.Entity<DietFood>()
                .HasKey(df => new { df.DietPlanId, df.FoodId });

            modelBuilder.Entity<DietSupplement>()
                .HasKey(ds => new { ds.DietPlanId, ds.SupplementId });


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Diet> DietPlans { get; set; }
        
        public DbSet<DietFood> DietPlanFoods { get; set; }
        
        public DbSet<DietSupplement> DietPlanSupplements { get; set; }
        
        public DbSet<Exercise> Exercises { get; set; }
        
        public DbSet<Food> Foods { get; set; }
        
        public DbSet<Supplement> Supplements { get; set; }
        
        public DbSet<SupplementBrand> SupplementBrands { get; set; }
        
        public DbSet<SupplementFlavour> SupplementFlavours { get; set; }
        
        public DbSet<Workout> Workouts { get; set; }
        
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
    }
}