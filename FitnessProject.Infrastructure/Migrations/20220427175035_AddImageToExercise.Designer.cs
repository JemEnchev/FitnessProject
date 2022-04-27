﻿// <auto-generated />
using System;
using FitnessProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitnessProject.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220427175035_AddImageToExercise")]
    partial class AddImageToExercise
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.Diet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Diets");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.DietFood", b =>
                {
                    b.Property<Guid>("DietId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FoodId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DietId", "FoodId");

                    b.HasIndex("FoodId");

                    b.ToTable("DietFoods");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.DietSupplement", b =>
                {
                    b.Property<Guid>("DietId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SupplementId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DietId", "SupplementId");

                    b.HasIndex("SupplementId");

                    b.ToTable("DietSupplements");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Difficulty")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsItBodyweight")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Requirements")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.Food", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CaloriesPer100")
                        .HasColumnType("int");

                    b.Property<byte>("CarbsPer100")
                        .HasColumnType("tinyint");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<byte>("FatPer100")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte>("ProteinPer100")
                        .HasColumnType("tinyint");

                    b.Property<int>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.Supplement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("FlavourId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("FlavourId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Supplements");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.SupplementBrand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("SupplementBrands");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.SupplementFlavour", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("SupplementFlavours");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.UserExercise", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "ExerciseId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("UserExercises");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.UserFood", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("FoodId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "FoodId");

                    b.HasIndex("FoodId");

                    b.ToTable("UserFoods");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.UserSupplement", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("SupplementId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "SupplementId");

                    b.HasIndex("SupplementId");

                    b.ToTable("UserSupplements");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.Workout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.WorkoutExercise", b =>
                {
                    b.Property<Guid>("ExerciseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WorkoutId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExerciseId", "WorkoutId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("WorkoutExercises");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.Diet", b =>
                {
                    b.HasOne("FitnessProject.Infrastructure.Data.Identity.ApplicationUser", "User")
                        .WithMany("Diets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.DietFood", b =>
                {
                    b.HasOne("FitnessProject.Infrastructure.Data.Models.Diet", "Diet")
                        .WithMany("DietFoods")
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessProject.Infrastructure.Data.Models.Food", "Food")
                        .WithMany("DietFoods")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diet");

                    b.Navigation("Food");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.DietSupplement", b =>
                {
                    b.HasOne("FitnessProject.Infrastructure.Data.Models.Diet", "Diet")
                        .WithMany("DietSupplements")
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessProject.Infrastructure.Data.Models.Supplement", "Supplement")
                        .WithMany("DietSupplements")
                        .HasForeignKey("SupplementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diet");

                    b.Navigation("Supplement");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.Supplement", b =>
                {
                    b.HasOne("FitnessProject.Infrastructure.Data.Models.SupplementBrand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessProject.Infrastructure.Data.Models.SupplementFlavour", "Flavour")
                        .WithMany()
                        .HasForeignKey("FlavourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Flavour");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.UserExercise", b =>
                {
                    b.HasOne("FitnessProject.Infrastructure.Data.Models.Exercise", "Exercise")
                        .WithMany("UserExercises")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessProject.Infrastructure.Data.Identity.ApplicationUser", "User")
                        .WithMany("FavouriteExercises")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.UserFood", b =>
                {
                    b.HasOne("FitnessProject.Infrastructure.Data.Models.Food", "Food")
                        .WithMany("UserFoods")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessProject.Infrastructure.Data.Identity.ApplicationUser", "User")
                        .WithMany("FavouriteFoods")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.UserSupplement", b =>
                {
                    b.HasOne("FitnessProject.Infrastructure.Data.Models.Supplement", "Supplement")
                        .WithMany("UserSupplements")
                        .HasForeignKey("SupplementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessProject.Infrastructure.Data.Identity.ApplicationUser", "User")
                        .WithMany("FavouriteSupplements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplement");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.Workout", b =>
                {
                    b.HasOne("FitnessProject.Infrastructure.Data.Identity.ApplicationUser", "User")
                        .WithMany("Workouts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.WorkoutExercise", b =>
                {
                    b.HasOne("FitnessProject.Infrastructure.Data.Models.Exercise", "Exercise")
                        .WithMany("WorkoutExercises")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessProject.Infrastructure.Data.Models.Workout", "Workout")
                        .WithMany("Exercises")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FitnessProject.Infrastructure.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FitnessProject.Infrastructure.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessProject.Infrastructure.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FitnessProject.Infrastructure.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Identity.ApplicationUser", b =>
                {
                    b.Navigation("Diets");

                    b.Navigation("FavouriteExercises");

                    b.Navigation("FavouriteFoods");

                    b.Navigation("FavouriteSupplements");

                    b.Navigation("Workouts");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.Diet", b =>
                {
                    b.Navigation("DietFoods");

                    b.Navigation("DietSupplements");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.Exercise", b =>
                {
                    b.Navigation("UserExercises");

                    b.Navigation("WorkoutExercises");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.Food", b =>
                {
                    b.Navigation("DietFoods");

                    b.Navigation("UserFoods");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.Supplement", b =>
                {
                    b.Navigation("DietSupplements");

                    b.Navigation("UserSupplements");
                });

            modelBuilder.Entity("FitnessProject.Infrastructure.Data.Models.Workout", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
