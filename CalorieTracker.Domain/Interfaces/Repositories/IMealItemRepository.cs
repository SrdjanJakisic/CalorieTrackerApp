using CalorieTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Domain.Interfaces.Repositories
{
    public interface IMealItemRepository
    {
        Task<MealItem?> GetByIdAsync(int id);
        Task UpdateAsync(MealItem item);
    }
}
