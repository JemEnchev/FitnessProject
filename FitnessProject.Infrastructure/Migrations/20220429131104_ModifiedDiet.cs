using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessProject.Infrastructure.Migrations
{
    public partial class ModifiedDiet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Breakfast",
                table: "Diets",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Dinner",
                table: "Diets",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lunch",
                table: "Diets",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Breakfast",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "Dinner",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "Lunch",
                table: "Diets");
        }
    }
}
