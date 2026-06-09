namespace CalorieTracker.Domain.Entities
{
    public class MealItem
    {
        public int Id { get; set; }
        public int MealId { get; set; }
        public int FoodItemId { get; set; }
        public int Quantity { get; set; }
        public bool IsEaten { get; set; }

        public Meal? Meal { get; set; }
        public FoodItem? FoodItem { get; set; }
    }
}
