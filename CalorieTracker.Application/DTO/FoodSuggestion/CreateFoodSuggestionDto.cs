using CalorieTracker.Domain.Enums;

namespace CalorieTracker.Application.DTO.FoodSuggestion
{
    public class CreateFoodSuggestionDto
    {
        public string Name { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public MeasureUnit Unit { get; set; }
        public float? AmountPerPiece { get; set; }
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }
        public bool IsLenten { get; set; }
    }
}
