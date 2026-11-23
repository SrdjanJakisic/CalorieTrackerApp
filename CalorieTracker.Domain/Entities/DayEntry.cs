namespace CalorieTracker.Domain.Entities
{
    public class DayEntry
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public DateOnly Date { get; set; }
        public bool IsLenten { get; set; }
        public bool Fasting { get; set; }

        public ICollection<FoodLogEntry> Entries { get; set; } = new List<FoodLogEntry>();

    }
}
