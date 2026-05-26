using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Application.DTO.FoodItem
{
    public class FoodItemSummaryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public float CaloriesPer100g { get; set; }
        public bool IsLenten { get; set; }
        public string? ImageUrl { get; set; }
    }
}
