using CalorieTracker.Domain.Entities;

namespace CalorieTracker.Domain.Interfaces.Repositories
{
    public interface IMealItemRepository
    {
        Task<MealItem?> GetByIdAsync(int id);
        Task UpdateAsync(MealItem item);
    }
}
