using CalorieTracker.Domain.Entities;

namespace CalorieTracker.Domain.Interfaces.Repositories
{
    public interface IMonthlyPlanRepository
    {
        Task<MonthlyPlan?> GetByUserMonthAsync(string userId, int year, int month);
        Task<DayEntry?> GetDayAsync(string userId, DateOnly date);
        Task CreateAsync(MonthlyPlan plan);
        Task UpdateAsync(MonthlyPlan plan);
    }
}
