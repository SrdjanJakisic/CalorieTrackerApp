using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Interfaces.Repositories;
using CalorieTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Infrastructure.Repositories
{
    public class FoodCategoryRepository:IFoodCategoryRepository
    {
        private readonly AppDbContext _db;

        public FoodCategoryRepository(AppDbContext db) => _db = db;
        public async Task CreateAsync(FoodCategory category) => await _db.FoodCategories.AddAsync(category);
        public async Task DeleteAsync(FoodCategory category) => _db.FoodCategories.Remove(category);
        public async Task<IEnumerable<FoodCategory>> GetAllAsync() => await _db.FoodCategories.ToListAsync();
        public async Task<FoodCategory?> GetByIdAsync(int id) => await _db.FoodCategories.FindAsync(id);
        public async Task UpdateAsync(FoodCategory category) => _db.FoodCategories.Update(category);
    }
}
