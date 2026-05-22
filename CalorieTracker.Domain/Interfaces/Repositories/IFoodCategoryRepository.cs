using CalorieTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Domain.Interfaces.Repositories
{
    public interface IFoodCategoryRepository
    {
        Task<IEnumerable<FoodCategory>> GetAllAsync();
        Task<FoodCategory?> GetByIdAsync(int id);
        Task CreateAsync(FoodCategory category);
        Task UpdateAsync(FoodCategory category);
        Task DeleteAsync(FoodCategory category);
    }
}
