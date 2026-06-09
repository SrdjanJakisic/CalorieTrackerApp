using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMeasureUnitAndAmountPerPieceToFoodSuggestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "AmountPerPiece",
                table: "FoodSuggestions",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Unit",
                table: "FoodSuggestions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountPerPiece",
                table: "FoodSuggestions");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "FoodSuggestions");
        }
    }
}
