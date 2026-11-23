using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Domain.Entities
{
    public class FoodLogEntry
    {
        public int Id { get; set; }
        public int DayEntryId { get; set; }
        public int FoodItemId { get; set; }
        public TimeOnly Time { get; set; }
        public float Quantity { get; set; }
        public string? ServingName { get; set; }
        public float? ServingCount { get; set; }

        public DayEntry? DayEntry { get; set; }
        public FoodItem? FoodItem { get; set; }
    }
}
