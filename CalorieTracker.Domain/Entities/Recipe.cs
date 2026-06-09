namespace CalorieTracker.Domain.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Instructions { get; set; }
        public bool IsPublic { get; set; }
        public string? UserId { get; set; }

        public ICollection<RecipeItem> Items { get; set; } = new List<RecipeItem>();
        public ICollection<RecipeImage> Images { get; set; } = new List<RecipeImage>();
    }
}
