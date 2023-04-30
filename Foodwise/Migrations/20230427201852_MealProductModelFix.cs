using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foodwise.Migrations
{
    /// <inheritdoc />
    public partial class MealProductModelFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Carbohydrates",
                table: "MealProducts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Fat",
                table: "MealProducts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Kcal",
                table: "MealProducts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Protein",
                table: "MealProducts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carbohydrates",
                table: "MealProducts");

            migrationBuilder.DropColumn(
                name: "Fat",
                table: "MealProducts");

            migrationBuilder.DropColumn(
                name: "Kcal",
                table: "MealProducts");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "MealProducts");
        }
    }
}
