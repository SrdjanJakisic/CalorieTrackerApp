using CalorieTracker.Domain.Enums;

namespace CalorieTracker.Application.DTO.FoodItem
{
    public class CreateFoodItemDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public MeasureUnit Unit { get; set; }
        public float? AmountPerPiece { get; set; }
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }
        public bool IsLenten { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? Source { get; set; }
    }
}
