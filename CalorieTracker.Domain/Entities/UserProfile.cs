using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CalorieTracker.Domain.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; } = string.Empty;
        public int CalorieGoal { get; set; }
        public int ProteinGoal { get; set; }
        public string? ProfileImageUrl { get; set; }
    }
}
