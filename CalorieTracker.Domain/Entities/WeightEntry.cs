namespace CalorieTracker.Domain.Entities
{
    public class WeightEntry
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public float Weight { get; set; }
        public DateOnly Date { get; set; }
    }
}
