using CalorieTracker.Application.DTO.FoodItem;
using CalorieTracker.Domain.Enums;
using FluentValidation;

namespace CalorieTracker.Application.Validators.FoodItem
{
    public class CreateFoodItemValidator:AbstractValidator<CreateFoodItemDto>
    {
        public CreateFoodItemValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Назив је обавезан!")
                .MaximumLength(100).WithMessage("Назив не може бити дужи од 100 знакова!");
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("категорија је обавезна!");
            RuleFor(x => x.Unit).IsInEnum().WithMessage("Неважећа јединица мере!");
            RuleFor(x => x.Calories).GreaterThanOrEqualTo(0).WithMessage("Калорије не могу бити негативне!");
            RuleFor(x => x.Protein).GreaterThanOrEqualTo(0).WithMessage("Протеин не може бити негативан!");
            RuleFor(x => x.Carbs).GreaterThanOrEqualTo(0).WithMessage("Угљени хидрати не могу бити негативни!");
            RuleFor(x => x.Fat).GreaterThanOrEqualTo(0).WithMessage("Масти не могу бити негативне!");
        }
    }
}
