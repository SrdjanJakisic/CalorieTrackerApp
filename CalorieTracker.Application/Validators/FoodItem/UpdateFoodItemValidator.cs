using CalorieTracker.Application.DTO.FoodItem;
using FluentValidation;

namespace CalorieTracker.Application.Validators.FoodItem
{
    public class UpdateFoodItemValidator:AbstractValidator<UpdateFoodItemDto>
    {
        public UpdateFoodItemValidator()
        {
            Include(new CreateFoodItemValidator());
        }
    }
}
