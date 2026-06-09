namespace CalorieTracker.Domain.Entities
{
    public class RecipeItem
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int FoodItemId { get; set; }
        public int Quantity { get; set; }

        public Recipe? Recipe { get; set; }
        public FoodItem? FoodItem { get; set; }
    }
}
