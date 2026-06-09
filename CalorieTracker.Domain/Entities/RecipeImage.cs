namespace CalorieTracker.Domain.Entities
{
    public class RecipeImage
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string ImageUrl { get; set; } = String.Empty;

        public Recipe? Recipe { get; set; }
    }
}
