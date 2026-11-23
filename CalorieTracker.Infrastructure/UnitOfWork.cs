using CalorieTracker.Domain.Interfaces;
using CalorieTracker.Domain.Interfaces.Repositories;
using CalorieTracker.Infrastructure.Data;

namespace CalorieTracker.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public IFoodCategoryRepository FoodCategories { get; }
        public IFoodItemRepository FoodItems { get; }
        public IFoodSuggestionRepository FoodSuggestions { get; }
        public IRecipeRepository Recipes { get; }
        public IWeightEntryRepository WeightEntries { get; }
        public IFoodLogEntryRepository FoodLogEntries { get; set; }
        public IDayRepository Days { get; set; }
        public UnitOfWork(AppDbContext db,
            IFoodSuggestionRepository foodSuggestions,
            IFoodItemRepository foodItems,
            IFoodCategoryRepository foodCategories,
            IRecipeRepository recipes,
            IWeightEntryRepository weightEntries,
            IFoodLogEntryRepository foodLogEntries,
            IDayRepository days)
        {
            _db = db;
            FoodCategories = foodCategories;
            FoodItems = foodItems;
            FoodSuggestions = foodSuggestions;
            Recipes = recipes;
            WeightEntries = weightEntries;
            Days = days;
            FoodLogEntries = foodLogEntries;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
