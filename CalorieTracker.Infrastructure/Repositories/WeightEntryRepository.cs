using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Interfaces.Repositories;
using CalorieTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Infrastructure.Repositories
{
    public class WeightEntryRepository : IWeightEntryRepository
    {
        private readonly AppDbContext _db;
        public WeightEntryRepository(AppDbContext db) => _db = db;
        public async Task CreateAsync(WeightEntry entry) => await _db.AddAsync(entry);
        public Task DeleteAsync(WeightEntry entry)
        {
            _db.Remove(entry);
            return Task.CompletedTask;
        }
        public async Task<IEnumerable<WeightEntry>> GetAllAsync(string userId) 
            => await _db.WeightEntries.Where(we => we.UserId == userId).ToListAsync();
        public async Task<WeightEntry?> GetByUserDateAsync(string userId, DateOnly date)
            => await _db.WeightEntries.FirstOrDefaultAsync(we => we.Date == date && we.UserId == userId);
        public Task UpdateAsync(WeightEntry entry)
        {
            _db.Update(entry);
            return Task.CompletedTask;
        }
    }
}
