using CalorieTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Domain.Interfaces.Repositories
{
    public interface IFoodItemRepository
    {
        Task<IEnumerable<FoodItem>> GetAllAsync(string? search, int? categoryId, bool? isLenten, bool? isApproved);
        Task<FoodItem> GetByIdAsync(int id);
        // Ако је Manufacturer null -> провеерава само по Name
        // Ако Manufacturer постоји -> проверава Name + Manufacturer
        Task<bool> ExistsASync(String name, string? manufacturer);
        Task CreateAsync(FoodItem item);
        Task UpdateAsync(FoodItem item);
        Task DeleteAsync(FoodItem item);
    }
}
