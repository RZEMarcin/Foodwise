using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foodwise.Migrations
{
    /// <inheritdoc />
    public partial class MealFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Carbs",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Fat",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Kcal",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Protein",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carbs",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Fat",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Kcal",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "Meals");
        }
    }
}
