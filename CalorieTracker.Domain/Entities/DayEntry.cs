namespace CalorieTracker.Domain.Entities
{
    public class DayEntry
    {
        public int Id { get; set; }
        public int MonthlyPlanId { get; set; }
        public DateOnly Date { get; set; }
        public bool IsLenten { get; set; }

        public MonthlyPlan? MonthlyPlan { get; set; }
        public ICollection<Meal> Meals { get; set; } = new List<Meal>();
    }
}
