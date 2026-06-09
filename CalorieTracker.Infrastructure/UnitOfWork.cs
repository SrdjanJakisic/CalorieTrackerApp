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
        public IMonthlyPlanRepository MonthlyPlans { get; }
        public IMealItemRepository MealItems { get; }
        public IWeightEntryRepository WeightEntries { get; }
        public UnitOfWork(AppDbContext db,
            IFoodSuggestionRepository foodSuggestions,
            IFoodItemRepository foodItems,
            IFoodCategoryRepository foodCategories,
            IRecipeRepository recipes,
            IMonthlyPlanRepository monthlyPlans,
            IMealItemRepository mealItems,
            IWeightEntryRepository weightEntries)
        {
            _db = db;
            FoodCategories = foodCategories;
            FoodItems = foodItems;
            FoodSuggestions = foodSuggestions;
            Recipes = recipes;
            MonthlyPlans = monthlyPlans;
            MealItems = mealItems;
            WeightEntries = weightEntries;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
