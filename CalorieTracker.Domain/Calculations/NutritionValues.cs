using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Domain.Calculations
{
    public class NutritionValues
    {
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }

        public NutritionValues Add(NutritionValues other)
        {
            return new NutritionValues
            {
                Calories = this.Calories + other.Calories,
                Protein = this.Protein + other.Protein,
                Carbs = this.Carbs + other.Carbs,
                Fat = this.Fat + other.Fat
            };
        }

    }
}
