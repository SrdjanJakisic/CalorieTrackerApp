using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Interfaces.Repositories;
using CalorieTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Infrastructure.Repositories
{
    public class DayRepository : IDayRepository
    {
        private readonly AppDbContext _db;
        public DayRepository(AppDbContext db) => _db = db;
        public async Task CreateAsync(DayEntry day) => await _db.AddAsync(day);
        public async Task<DayEntry?> GetByDateAsync(string userId, DateOnly date)
            => await _db.DayEntries
            .Include(x => x.Entries)
            .ThenInclude(x => x.FoodItem)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Date == date);
        public async Task<IEnumerable<DayEntry>> GetRangeAsync(string userId, DateOnly from, DateOnly to)
            => await _db.DayEntries
            .Include(x => x.Entries)
            .ThenInclude(x => x.FoodItem)
            .Where(x => x.UserId == userId && x.Date >= from && x.Date <= to)
            .OrderBy(x => x.Date)
            .ToListAsync();
        public Task UpdateAsync(DayEntry day)
        {
            _db.DayEntries.Update(day);
            return Task.CompletedTask;
        }
    }
}
