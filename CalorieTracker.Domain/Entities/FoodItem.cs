using CalorieTracker.Domain.Enums;

namespace CalorieTracker.Domain.Entities
{
    public class FoodItem
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Manufacturer { get; set; }
        public MeasureUnit Unit { get; set; }
        public float? AmountPerPiece { get; set; }
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }
        public bool IsLenten { get; set; }
        public bool IsApproved { get; set; } = true;
        public string? AdditionalInfo { get; set; }
        public string? Source { get; set; }
        public string? ImageUrl { get; set; }

        public FoodCategory? Category { get; set; }

    }
}
