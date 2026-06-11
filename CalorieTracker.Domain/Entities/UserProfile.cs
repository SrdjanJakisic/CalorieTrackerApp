using CalorieTracker.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CalorieTracker.Domain.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; } = string.Empty;
        public Gender? Gender { get; set; }
        public float? Height { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public int? CalorieGoal { get; set; }
        public int? ProteinGoal { get; set; }
        public int? CarbsGoal { get; set; }
        public int? FatGoal { get; set; }

        public string? ProfileImageUrl { get; set; }
    }
}
