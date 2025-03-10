using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foodwise.Migrations
{
    /// <inheritdoc />
    public partial class AddMealTotalInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Carbs",
                table: "Meals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Fat",
                table: "Meals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Kcal",
                table: "Meals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Protein",
                table: "Meals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
