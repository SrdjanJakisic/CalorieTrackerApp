using CalorieTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Domain.Interfaces.Repositories
{
    public interface IWeightEntryRepository
    {
        Task<IEnumerable<WeightEntry>> GetAllAsync(string userId);
        Task<WeightEntry?> GetByUserDateAsync(string userId, DateOnly date);
        Task CreateAsync(WeightEntry entry);
        Task UpdateAsync(WeightEntry entry);
        Task DeleteAsync(WeightEntry entry);
    }
}
