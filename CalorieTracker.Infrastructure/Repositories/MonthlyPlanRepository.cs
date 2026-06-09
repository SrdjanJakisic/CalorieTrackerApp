using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Interfaces.Repositories;
using CalorieTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Infrastructure.Repositories
{
    public class MonthlyPlanRepository : IMonthlyPlanRepository
    {
        private readonly AppDbContext _db;
        public MonthlyPlanRepository(AppDbContext db) => _db = db;
        public async Task CreateAsync(MonthlyPlan plan) => await _db.MonthlyPlans.AddAsync(plan);
        public async Task<MonthlyPlan?> GetByUserMonthAsync(string userId, int year, int month)
            => await _db.MonthlyPlans.Include(mp => mp.Days).ThenInclude(d => d.Meals).ThenInclude(m => m.MealItems)
            .ThenInclude(mi => mi.FoodItem).FirstOrDefaultAsync(mp => mp.UserId == userId && mp.Year == year && mp.Month == month);
        public async Task<DayEntry?> GetDayAsync(string userId, DateOnly date)
            => await _db.DayEntries.Include(de => de.Meals).ThenInclude(m => m.MealItems).ThenInclude(mi => mi.FoodItem)
            .FirstOrDefaultAsync(de => de.Date == date && de.MonthlyPlan!.UserId == userId);
        public Task UpdateAsync(MonthlyPlan plan)
        {
            _db.MonthlyPlans.Update(plan);
            return Task.CompletedTask;
        }
    }
}
