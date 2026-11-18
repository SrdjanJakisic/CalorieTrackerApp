using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Domain.Entities
{
    public class FoodServing
    {
        public int Id { get; set; }
        public int FoodItemId { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        public int SortOrder { get; set; }

        public FoodItem? FoodItem { get; set; }
    }
}
