using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessProject.Infrastructure.Migrations
{
    public partial class AddedVideoToExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Video",
                table: "Exercises");
        }
    }
}
