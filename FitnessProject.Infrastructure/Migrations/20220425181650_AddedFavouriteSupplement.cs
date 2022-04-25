using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessProject.Infrastructure.Migrations
{
    public partial class AddedFavouriteSupplement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExercise_AspNetUsers_UserId",
                table: "UserExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExercise_Exercises_ExerciseId",
                table: "UserExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFood_AspNetUsers_UserId",
                table: "UserFood");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFood_Foods_FoodId",
                table: "UserFood");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFood",
                table: "UserFood");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserExercise",
                table: "UserExercise");

            migrationBuilder.RenameTable(
                name: "UserFood",
                newName: "UserFoods");

            migrationBuilder.RenameTable(
                name: "UserExercise",
                newName: "UserExercises");

            migrationBuilder.RenameIndex(
                name: "IX_UserFood_FoodId",
                table: "UserFoods",
                newName: "IX_UserFoods_FoodId");

            migrationBuilder.RenameIndex(
                name: "IX_UserExercise_ExerciseId",
                table: "UserExercises",
                newName: "IX_UserExercises_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFoods",
                table: "UserFoods",
                columns: new[] { "UserId", "FoodId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserExercises",
                table: "UserExercises",
                columns: new[] { "UserId", "ExerciseId" });

            migrationBuilder.CreateTable(
                name: "UserSupplements",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SupplementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSupplements", x => new { x.UserId, x.SupplementId });
                    table.ForeignKey(
                        name: "FK_UserSupplements_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSupplements_Supplements_SupplementId",
                        column: x => x.SupplementId,
                        principalTable: "Supplements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSupplements_SupplementId",
                table: "UserSupplements",
                column: "SupplementId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExercises_AspNetUsers_UserId",
                table: "UserExercises",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExercises_Exercises_ExerciseId",
                table: "UserExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFoods_AspNetUsers_UserId",
                table: "UserFoods",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFoods_Foods_FoodId",
                table: "UserFoods",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExercises_AspNetUsers_UserId",
                table: "UserExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExercises_Exercises_ExerciseId",
                table: "UserExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFoods_AspNetUsers_UserId",
                table: "UserFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFoods_Foods_FoodId",
                table: "UserFoods");

            migrationBuilder.DropTable(
                name: "UserSupplements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFoods",
                table: "UserFoods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserExercises",
                table: "UserExercises");

            migrationBuilder.RenameTable(
                name: "UserFoods",
                newName: "UserFood");

            migrationBuilder.RenameTable(
                name: "UserExercises",
                newName: "UserExercise");

            migrationBuilder.RenameIndex(
                name: "IX_UserFoods_FoodId",
                table: "UserFood",
                newName: "IX_UserFood_FoodId");

            migrationBuilder.RenameIndex(
                name: "IX_UserExercises_ExerciseId",
                table: "UserExercise",
                newName: "IX_UserExercise_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFood",
                table: "UserFood",
                columns: new[] { "UserId", "FoodId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserExercise",
                table: "UserExercise",
                columns: new[] { "UserId", "ExerciseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserExercise_AspNetUsers_UserId",
                table: "UserExercise",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExercise_Exercises_ExerciseId",
                table: "UserExercise",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFood_AspNetUsers_UserId",
                table: "UserFood",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFood_Foods_FoodId",
                table: "UserFood",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
