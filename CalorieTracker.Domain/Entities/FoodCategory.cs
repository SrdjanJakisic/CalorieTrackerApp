using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Domain.Entities
{
    public class FoodCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<FoodItem> Items { get; set; } = new List<FoodItem>();
    }
}
