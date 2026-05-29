using CalorieTracker.Application.DTO.FoodCategory;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Application.Validators.FoodCategory
{
    public class CreateFoodCategoryValidator:AbstractValidator<CreateFoodCategoryDto>
    {
        public CreateFoodCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }
}
