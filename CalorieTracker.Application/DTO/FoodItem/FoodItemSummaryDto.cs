using CalorieTracker.Domain.Enums;

namespace CalorieTracker.Application.DTO.FoodItem
{
    public class FoodItemSummaryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Manufacturer { get; set; }
        public MeasureUnit Unit { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public float Calories { get; set; }
        public bool IsLenten { get; set; }
        public string? ImageUrl { get; set; }
    }
}
