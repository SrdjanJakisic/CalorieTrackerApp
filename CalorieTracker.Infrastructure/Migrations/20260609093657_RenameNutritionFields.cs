using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameNutritionFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProteinPer100g",
                table: "FoodSuggestions",
                newName: "Protein");

            migrationBuilder.RenameColumn(
                name: "FatPer100g",
                table: "FoodSuggestions",
                newName: "Fat");

            migrationBuilder.RenameColumn(
                name: "CarbsPer100g",
                table: "FoodSuggestions",
                newName: "Carbs");

            migrationBuilder.RenameColumn(
                name: "CaloriesPer100g",
                table: "FoodSuggestions",
                newName: "Calories");

            migrationBuilder.RenameColumn(
                name: "ProteinPer100g",
                table: "FoodItems",
                newName: "Protein");

            migrationBuilder.RenameColumn(
                name: "GramsPerPiece",
                table: "FoodItems",
                newName: "AmountPerPiece");

            migrationBuilder.RenameColumn(
                name: "FatPer100g",
                table: "FoodItems",
                newName: "Fat");

            migrationBuilder.RenameColumn(
                name: "CarbsPer100g",
                table: "FoodItems",
                newName: "Carbs");

            migrationBuilder.RenameColumn(
                name: "CaloriesPer100g",
                table: "FoodItems",
                newName: "Calories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Protein",
                table: "FoodSuggestions",
                newName: "ProteinPer100g");

            migrationBuilder.RenameColumn(
                name: "Fat",
                table: "FoodSuggestions",
                newName: "FatPer100g");

            migrationBuilder.RenameColumn(
                name: "Carbs",
                table: "FoodSuggestions",
                newName: "CarbsPer100g");

            migrationBuilder.RenameColumn(
                name: "Calories",
                table: "FoodSuggestions",
                newName: "CaloriesPer100g");

            migrationBuilder.RenameColumn(
                name: "Protein",
                table: "FoodItems",
                newName: "ProteinPer100g");

            migrationBuilder.RenameColumn(
                name: "Fat",
                table: "FoodItems",
                newName: "FatPer100g");

            migrationBuilder.RenameColumn(
                name: "Carbs",
                table: "FoodItems",
                newName: "CarbsPer100g");

            migrationBuilder.RenameColumn(
                name: "Calories",
                table: "FoodItems",
                newName: "CaloriesPer100g");

            migrationBuilder.RenameColumn(
                name: "AmountPerPiece",
                table: "FoodItems",
                newName: "GramsPerPiece");
        }
    }
}
