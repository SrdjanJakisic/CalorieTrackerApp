using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Application.DTO.FoodCategory
{
    public class CreateFoodCategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
