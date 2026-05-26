using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace CalorieTracker.Domain.Entities
{
    public class FoodCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ICollection<FoodItem> Items { get; set; } = new List<FoodItem>();
    }
}
