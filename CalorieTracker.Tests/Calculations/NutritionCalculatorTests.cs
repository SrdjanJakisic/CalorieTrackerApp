using CalorieTracker.Domain.Calculations;
using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Enums;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Tests.Calculations
{
    public class NutritionCalculatorTests
    {
        private static FoodItem CreateFood(MeasureUnit unit, float calories = 100, float protein = 10
            , float carbs = 20, float fat =5)
        {
            return new FoodItem
            {
                Unit = unit,
                Calories = calories,
                Protein = protein,
                Carbs = carbs,
                Fat = fat
            };
        }

        [Fact]
        public void ForItem_GramUnit_ScalesByQuantityOver100()
        {
            var food = CreateFood(MeasureUnit.Gram, calories: 52);

            var result = NutritionCalculator.ForItem(250, food);

            result.Calories.Should().Be(130);
        }

        [Fact]
        public void ForItem_MilliliterUnit_ScaleByQuantityOver100()
        {
            var food = CreateFood(MeasureUnit.Milliliter, calories: 884);

            var result = NutritionCalculator.ForItem(50, food);

            result.Calories.Should().Be(442);
        }

        [Fact]
        public void ForItem_PieceUnit_MultiplesByQuantityDirectly()
        {
            var food = CreateFood(MeasureUnit.Piece, calories: 114);

            var result = NutritionCalculator.ForItem(3, food);

            result.Calories.Should().Be(342);
        }

        [Fact]
        public void ForItem_ZeroQuantity_ReturnsZero()
        {
            var food = CreateFood(MeasureUnit.Gram, calories: 100);

            var result = NutritionCalculator.ForItem(0, food);

            result.Calories.Should().Be(0);
            result.Protein.Should().Be(0);
            result.Carbs.Should().Be(0);
            result.Fat.Should().Be(0);
        }

        [Fact]
        public void ForItem_AllMacrosScaledTogether()
        {
            var food = CreateFood(MeasureUnit.Gram, calories: 165, protein: 31, carbs: 0, fat: 3.6f);

            var result = NutritionCalculator.ForItem(200, food);

            result.Calories.Should().Be(330);
            result.Protein.Should().Be(62);
            result.Carbs.Should().Be(0);
            result.Fat.Should().BeApproximately(7.2f, 0.01f);
        }
    }
}
