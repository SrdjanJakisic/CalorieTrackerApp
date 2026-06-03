using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Domain.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool isPublic { get; set; }
        public string? UserId { get; set; }

        public ICollection<RecipeItem> Items { get; set; } = new List<RecipeItem>();
        public ICollection<RecipeImage> Images { get; set; } = new List<RecipeImage>();
    }
}
