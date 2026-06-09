using CalorieTracker.Application.DTO.FoodCategory;
using FluentValidation;

namespace CalorieTracker.Application.Validators.FoodCategory
{
    public class CreateFoodCategoryValidator:AbstractValidator<CreateFoodCategoryDto>
    {
        public CreateFoodCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Назив је обавезан!")
                .MaximumLength(100).WithMessage("Назив не може бити дужи од 100 знакова!");
        }
    }
}
