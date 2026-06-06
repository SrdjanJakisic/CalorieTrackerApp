using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Interfaces.Repositories;
using CalorieTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Infrastructure.Repositories
{
    public class MealItemRepository : IMealItemRepository
    {
        private readonly AppDbContext _db;
        public MealItemRepository(AppDbContext db) => _db = db;
        public async Task<MealItem?> GetByIdAsync(int id)
            => await _db.MealItems.FindAsync(id);
        public Task UpdateAsync(MealItem item)
        {
            _db.Update(item);
            return Task.CompletedTask;
        }
    }
}
