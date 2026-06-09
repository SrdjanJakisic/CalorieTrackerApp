using CalorieTracker.Domain.Entities;

namespace CalorieTracker.Domain.Interfaces.Repositories
{
    public interface IFoodItemRepository
    {
        Task<IEnumerable<FoodItem>> GetAllAsync(string? search, int? categoryId, bool? isLenten, bool? isApproved);
        Task<FoodItem?> GetByIdAsync(int id);
        // Ако је Manufacturer null -> провеерава само по Name
        // Ако Manufacturer постоји -> проверава Name + Manufacturer
        Task<bool> ExistsAsync(string name, string? manufacturer);
        Task CreateAsync(FoodItem item);
        Task UpdateAsync(FoodItem item);
        Task DeleteAsync(FoodItem item);
    }
}
