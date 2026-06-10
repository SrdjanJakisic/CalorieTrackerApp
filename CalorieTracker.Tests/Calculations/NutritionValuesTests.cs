using CalorieTracker.Domain.Calculations;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Tests.Calculations
{
    public class NutritionValuesTests
    {
        [Fact]
        public void Add_TwoInstances_SumsAllFields()
        {
            var a = new NutritionValues { Calories = 100, Protein = 10, Carbs = 20, Fat = 5 };
            var b = new NutritionValues { Calories = 50, Protein = 5, Carbs = 10, Fat = 2 };

            var sum = a.Add(b);

            sum.Calories.Should().Be(150);
            sum.Protein.Should().Be(15);
            sum.Carbs.Should().Be(30);
            sum.Fat.Should().Be(7);
        }

        [Fact]
        public void Add_EmptyToFull_ReturnsFull()
        {
            var empty = new NutritionValues();
            var full = new NutritionValues { Calories = 100, Protein = 10 };

            var sum = empty.Add(full);

            sum.Calories.Should().Be(100);
            sum.Protein.Should().Be(10);
        }
    }
}
