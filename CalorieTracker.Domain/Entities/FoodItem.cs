using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Domain.Entities
{
    public class FoodItem
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Manufacturer { get; set; }
        public float CaloriesPer100g { get; set; }
        public float ProteinPer100g { get; set; }
        public float CarbsPer100g { get; set; }
        public float FatPer100g { get; set; }
        public bool IsLenten { get; set; }
        public bool IsApproved { get; set; } = true;
        public string? AdditionalInfo { get; set; }
        public string? Source { get; set; }
        public string? ImageUrl { get; set; }

        public FoodCategory? Category { get; set; }

    }
}
