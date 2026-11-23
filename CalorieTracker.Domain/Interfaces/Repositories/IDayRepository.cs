using CalorieTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Domain.Interfaces.Repositories
{
    public interface IDayRepository
    {
        Task<DayEntry?> GetByDateAsync(string userId, DateOnly date);
        Task<IEnumerable<DayEntry>> GetRangeAsync(string userId, DateOnly from, DateOnly to);
        Task CreateAsync(DayEntry day);
        Task UpdateAsync(DayEntry day);
    }
}
