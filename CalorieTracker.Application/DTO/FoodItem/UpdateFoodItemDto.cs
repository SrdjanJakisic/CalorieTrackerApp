namespace CalorieTracker.Application.DTO.FoodItem
{
    public class UpdateFoodItemDto:CreateFoodItemDto
    {
        public bool IsApproved { get; set; }
    }
}
