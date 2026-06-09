namespace CalorieTracker.Domain.Entities
{
    public class Meal
    {
        public int Id{ get; set; }
        public int DayEntryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public TimeOnly? Time { get; set; }

        public DayEntry? DayEntry { get; set; }
        public ICollection<MealItem> MealItems { get; set; } = new List<MealItem>();
    }
}
