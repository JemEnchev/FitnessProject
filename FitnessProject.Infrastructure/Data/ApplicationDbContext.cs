namespace FitnessProject.Infrastructure.Data
{
    using FitnessProject.Infrastructure.Data.Identity;
    using FitnessProject.Infrastructure.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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


            modelBuilder.Entity<DietFood>()
                .HasKey(df => new { df.DietId, df.FoodId });

            modelBuilder.Entity<DietSupplement>()
                .HasKey(ds => new { ds.DietId, ds.SupplementId }); 
            
            modelBuilder.Entity<UserExercise>()
                .HasKey(ue => new { ue.UserId, ue.ExerciseId });

            modelBuilder.Entity<UserFood>()
                .HasKey(uf => new { uf.UserId, uf.FoodId });

            modelBuilder.Entity<UserSupplement>()
               .HasKey(us => new { us.UserId, us.SupplementId });


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Diet> Diets { get; set; }
        
        public DbSet<DietFood> DietFoods { get; set; }
        
        public DbSet<DietSupplement> DietSupplements { get; set; }
        
        public DbSet<Exercise> Exercises { get; set; }
        
        public DbSet<Food> Foods { get; set; }
        
        public DbSet<Supplement> Supplements { get; set; }
        
        public DbSet<SupplementBrand> SupplementBrands { get; set; }
        
        public DbSet<SupplementFlavour> SupplementFlavours { get; set; }

        public DbSet<UserExercise> UserExercises { get; set; }

        public DbSet<UserFood> UserFoods { get; set; }

        public DbSet<UserSupplement> UserSupplements { get; set; }
    }
}