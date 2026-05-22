using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Interfaces.Repositories;
using CalorieTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Infrastructure.Repositories
{
    public class FoodItemRepository : IFoodItemRepository
    {
        private readonly AppDbContext _db;
        public FoodItemRepository(AppDbContext db) => _db = db;
        public async Task CreateAsync(FoodItem item) => await _db.FoodItems.AddAsync(item);
        public async Task DeleteAsync(FoodItem item) => _db.FoodItems.Remove(item);
        public async Task<bool> ExistsASync(string name, string? manufacturer) => await _db.FoodItems.AnyAsync(x => x.Name == name && x.Manufacturer == manufacturer);
        public async Task<IEnumerable<FoodItem>> GetAllAsync(string? search, int? categoryId, bool? isLenten, bool? isApproved)
        {
            var query = _db.FoodItems.Include(x => x.Category).AsQueryable();

            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Name.Contains(search) || x.Manufacturer.Contains(search));
            }

            if (categoryId.HasValue) 
            {
                query = query.Where(x => x.CategoryId == categoryId.Value);
            }

            if(isLenten.HasValue)
            {
                query = query.Where(x => x.IsLenten == isLenten.Value);
            }

            if(isApproved.HasValue)
            {
                query = query.Where(x => x.IsApproved == isApproved.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<FoodItem?> GetByIdAsync(int id) => await _db.FoodItems.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
        public async Task UpdateAsync(FoodItem item) => _db.FoodItems.Update(item);
    }
}
