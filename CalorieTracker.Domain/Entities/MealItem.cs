using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Domain.Entities
{
    public class MealItem
    {
        public int Id { get; set; }
        public int MealId { get; set; }
        public int FoodItemId { get; set; }
        public int Grams { get; set; }
        public bool IsEaten { get; set; }

        public Meal? Meal { get; set; }
        public FoodItem? FoodItem { get; set; }
    }
}
