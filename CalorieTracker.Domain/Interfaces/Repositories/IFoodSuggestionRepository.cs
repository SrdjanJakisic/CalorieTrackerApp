using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Enums;

namespace CalorieTracker.Domain.Interfaces.Repositories
{
    public interface IFoodSuggestionRepository
    {
        Task<IEnumerable<FoodSuggestion>> GetAllAsync(SuggestionStatus? status);
        Task<FoodSuggestion?> GetByIdAsync(int id);
        Task CreateAsync(FoodSuggestion suggestion);
        Task UpdateAsync(FoodSuggestion suggestion);
        Task<bool> ExistsAsync(string name, string? manufacturer);
    }
}
