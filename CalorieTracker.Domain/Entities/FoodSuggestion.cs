using CalorieTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Domain.Entities
{
    public class FoodSuggestion
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Manufacturer { get; set; }
        public int CategoryId { get; set; }
        public float CaloriesPer100g { get; set; }
        public float ProteinPer100g { get; set; }
        public float CarbsPer100g { get; set; }
        public float FatPer100g { get; set; }
        public bool IsLenten { get; set; }
        public SuggestionStatus Status { get; set; } = SuggestionStatus.Pending;
        public string? AdminNote { get; set; }
    }
}
