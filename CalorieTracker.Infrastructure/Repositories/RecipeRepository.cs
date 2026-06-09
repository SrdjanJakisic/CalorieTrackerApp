using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Interfaces.Repositories;
using CalorieTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Infrastructure.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly AppDbContext _db;
        public RecipeRepository(AppDbContext db) => _db = db;
        public async Task CreateAsync(Recipe recipe) => await _db.AddAsync(recipe);
        public Task DeleteAsync(Recipe recipe)
        {
            _db.Remove(recipe);
            return Task.CompletedTask;
        }
        public async Task<IEnumerable<Recipe>> GetAllAsync(string userId) 
            => await _db.Recipes.Include(r => r.Images).Where(r => r.UserId == userId || r.UserId == null).ToListAsync();
        public async Task<Recipe?> GetByIdAsync(int id) 
            => await _db.Recipes.Include(r => r.Items).ThenInclude(i => i.FoodItem).Include(r => r.Images).FirstOrDefaultAsync(r => r.Id == id);
        public Task UpdateAsync(Recipe recipe)
        {
            _db.Update(recipe);
            return Task.CompletedTask;
        }
    }
}
