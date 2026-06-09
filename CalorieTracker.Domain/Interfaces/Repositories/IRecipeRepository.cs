using CalorieTracker.Domain.Entities;

namespace CalorieTracker.Domain.Interfaces.Repositories
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetAllAsync(string userId);
        Task<Recipe?> GetByIdAsync(int id);
        Task CreateAsync(Recipe recipe);
        Task UpdateAsync(Recipe recipe);
        Task DeleteAsync(Recipe recipe);
    }
}
