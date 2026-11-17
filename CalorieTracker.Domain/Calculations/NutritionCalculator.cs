using CalorieTracker.Domain.Entities;

namespace CalorieTracker.Domain.Calculations
{
    public static class NutritionCalculator
    {
        public static NutritionValues ForItem(float quantity, FoodItem food)
        {
            var factor = quantity / 100f;

            return new NutritionValues
            {
                Calories = factor * food.Calories,
                Protein = factor * food.Protein,
                Carbs = factor * food.Carbs,
                Fat = factor * food.Fat
            };
        }
    }
}
