using CalorieTracker.Application.DTO.FoodSuggestion;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Application.Validators.FoodSuggestion
{
    public class CreateFoodSuggestionValidator:AbstractValidator<CreateFoodSuggestionDto>
    {
        public CreateFoodSuggestionValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Manufacturer).NotEmpty();
            RuleFor(x => x.CategoryId).GreaterThan(0);
            RuleFor(x => x.CaloriesPer100g).GreaterThanOrEqualTo(0);
            RuleFor(x => x.ProteinPer100g).GreaterThanOrEqualTo(0);
            RuleFor(x => x.CarbsPer100g).GreaterThanOrEqualTo(0);
            RuleFor(x => x.FatPer100g).GreaterThanOrEqualTo(0);
        }
    }
}
