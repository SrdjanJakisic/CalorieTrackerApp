using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addMeasureUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Grams",
                table: "RecipeItems",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "Grams",
                table: "MealItems",
                newName: "Quantity");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "Time",
                table: "Meals",
                type: "time",
                nullable: true,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AddColumn<float>(
                name: "GramsPerPiece",
                table: "FoodItems",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Unit",
                table: "FoodItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GramsPerPiece",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "FoodItems");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "RecipeItems",
                newName: "Grams");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "MealItems",
                newName: "Grams");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "Time",
                table: "Meals",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0),
                oldClrType: typeof(TimeOnly),
                oldType: "time",
                oldNullable: true);
        }
    }
}
