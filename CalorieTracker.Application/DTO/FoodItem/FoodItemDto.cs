using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Application.DTO.FoodItem
{
    public class FoodItemDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public float CaloriesPer100g { get; set; }
        public float ProteinPer100g { get; set; }
        public float CarbsPer100g { get; set; }
        public float FatPer100g { get; set; }
        public bool IsLentent { get; set; }
        public bool IsApproved { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? Source { get; set; }
        public string? ImageUrl { get; set; }

    }
}
