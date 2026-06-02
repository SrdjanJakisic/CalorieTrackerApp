using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Domain.Entities
{
    public class MonthlyPlan
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int Year { get; set; }
        public int Month { get; set; }

        public ICollection<DayEntry> Days { get; set; } = new List<DayEntry>();
    }
}
