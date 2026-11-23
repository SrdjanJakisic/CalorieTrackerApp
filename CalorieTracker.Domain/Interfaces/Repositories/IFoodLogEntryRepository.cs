using CalorieTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Domain.Interfaces.Repositories
{
    public interface IFoodLogEntryRepository
    {
        Task<FoodLogEntry?> GetByIdAsync(int id);
        Task CreateAsync(FoodLogEntry entry);
        Task UpdateAync(FoodLogEntry entry);
        Task DeleteAsync(FoodLogEntry entry);
    }
}
