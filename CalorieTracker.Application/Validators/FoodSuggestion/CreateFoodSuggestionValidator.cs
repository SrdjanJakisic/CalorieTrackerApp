using CalorieTracker.Application.DTO.FoodSuggestion;
using CalorieTracker.Domain.Enums;
using FluentValidation;

namespace CalorieTracker.Application.Validators.FoodSuggestion
{
    public class CreateFoodSuggestionValidator:AbstractValidator<CreateFoodSuggestionDto>
    {
        public CreateFoodSuggestionValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.CategoryId).GreaterThan(0);
            RuleFor(x => x.Unit).IsInEnum();
            RuleFor(x => x.Calories).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Protein).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Carbs).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Fat).GreaterThanOrEqualTo(0);
        }
    }
}
