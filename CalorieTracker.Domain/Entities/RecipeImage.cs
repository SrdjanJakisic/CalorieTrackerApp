using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Domain.Entities
{
    public class RecipeImage
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string ImageUrl { get; set; }

        public Recipe? Recipe { get; set; }
    }
}
