using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Application.DTO.FoodItem
{
    public class FoodServingDto
    {
        public string Name { get; set; } = string.Empty;
        public float Amount { get; set; }
    }
}
