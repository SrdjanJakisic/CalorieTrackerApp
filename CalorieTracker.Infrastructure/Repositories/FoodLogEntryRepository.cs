using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Interfaces.Repositories;
using CalorieTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Infrastructure.Repositories
{
    public class FoodLogEntryRepository : IFoodLogEntryRepository
    {
        private readonly AppDbContext _db;
        public FoodLogEntryRepository(AppDbContext db) => _db = db;
        public async Task CreateAsync(FoodLogEntry entry) => await _db.FoodLogEntries.AddAsync(entry);
        public Task DeleteAsync(FoodLogEntry entry)
        {
            _db.FoodLogEntries.Remove(entry);
            return Task.CompletedTask;
        }
        public async Task<FoodLogEntry?> GetByIdAsync(int id)
            => await _db.FoodLogEntries
            .Include(x => x.DayEntry)
            .FirstOrDefaultAsync(x => x.Id == id);
        public Task UpdateAync(FoodLogEntry entry)
        {
            _db.FoodLogEntries.Update(entry);
            return Task.CompletedTask;
        }
    }
}
