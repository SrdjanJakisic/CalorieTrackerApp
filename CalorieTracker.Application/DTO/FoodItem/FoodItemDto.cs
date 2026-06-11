using CalorieTracker.Domain.Enums;

namespace CalorieTracker.Application.DTO.FoodItem
{
    public class FoodItemDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Manufacturer { get; set; }
        public MeasureUnit Unit { get; set; }
        public float? AmountPerPiece { get; set; }
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }
        public bool IsLenten { get; set; }
        public bool IsApproved { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? Source { get; set; }
        public string? ImageUrl { get; set; }

    }
}
