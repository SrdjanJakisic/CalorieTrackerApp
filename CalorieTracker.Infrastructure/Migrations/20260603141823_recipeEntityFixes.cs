using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class recipeEntityFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeImage_Recipes_RecipeId",
                table: "RecipeImage");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeItem_FoodItems_FoodItemId",
                table: "RecipeItem");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeItem_Recipes_RecipeId",
                table: "RecipeItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeItem",
                table: "RecipeItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeImage",
                table: "RecipeImage");

            migrationBuilder.RenameTable(
                name: "RecipeItem",
                newName: "RecipeItems");

            migrationBuilder.RenameTable(
                name: "RecipeImage",
                newName: "RecipeImages");

            migrationBuilder.RenameColumn(
                name: "isPublic",
                table: "Recipes",
                newName: "IsPublic");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeItem_RecipeId",
                table: "RecipeItems",
                newName: "IX_RecipeItems_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeItem_FoodItemId",
                table: "RecipeItems",
                newName: "IX_RecipeItems_FoodItemId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeImage_RecipeId",
                table: "RecipeImages",
                newName: "IX_RecipeImages_RecipeId");

            migrationBuilder.AddColumn<string>(
                name: "Instructions",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeItems",
                table: "RecipeItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeImages",
                table: "RecipeImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeImages_Recipes_RecipeId",
                table: "RecipeImages",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeItems_FoodItems_FoodItemId",
                table: "RecipeItems",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeItems_Recipes_RecipeId",
                table: "RecipeItems",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeImages_Recipes_RecipeId",
                table: "RecipeImages");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeItems_FoodItems_FoodItemId",
                table: "RecipeItems");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeItems_Recipes_RecipeId",
                table: "RecipeItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeItems",
                table: "RecipeItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeImages",
                table: "RecipeImages");

            migrationBuilder.DropColumn(
                name: "Instructions",
                table: "Recipes");

            migrationBuilder.RenameTable(
                name: "RecipeItems",
                newName: "RecipeItem");

            migrationBuilder.RenameTable(
                name: "RecipeImages",
                newName: "RecipeImage");

            migrationBuilder.RenameColumn(
                name: "IsPublic",
                table: "Recipes",
                newName: "isPublic");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeItems_RecipeId",
                table: "RecipeItem",
                newName: "IX_RecipeItem_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeItems_FoodItemId",
                table: "RecipeItem",
                newName: "IX_RecipeItem_FoodItemId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeImages_RecipeId",
                table: "RecipeImage",
                newName: "IX_RecipeImage_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeItem",
                table: "RecipeItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeImage",
                table: "RecipeImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeImage_Recipes_RecipeId",
                table: "RecipeImage",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeItem_FoodItems_FoodItemId",
                table: "RecipeItem",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeItem_Recipes_RecipeId",
                table: "RecipeItem",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
