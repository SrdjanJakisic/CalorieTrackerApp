using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Enums;

namespace CalorieTracker.Domain.Calculations
{
    public static class NutritionCalculator
    {
        public static NutritionValues ForItem(int quantity, FoodItem food)
        {
            var factor = food.Unit == MeasureUnit.Piece ? quantity : quantity / 100f;

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
