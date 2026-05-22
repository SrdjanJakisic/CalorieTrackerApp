using CalorieTracker.Domain.Interfaces;
using CalorieTracker.Domain.Interfaces.Repositories;
using CalorieTracker.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public IFoodCategoryRepository FoodCategories { get; set; }
        public IFoodItemRepository FoodItems { get; set; }
        public IFoodSuggestionRepository FoodSuggestions { get; set; }
        public UnitOfWork(AppDbContext db,
            IFoodSuggestionRepository foodSuggestions,
            IFoodItemRepository foodItems,
            IFoodCategoryRepository foodCategories)
        {
            _db = db;
            FoodCategories = foodCategories;
            FoodItems = foodItems;
            FoodSuggestions = foodSuggestions;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
