using CalorieTracker.Domain.Interfaces.Repositories;

namespace CalorieTracker.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        IFoodCategoryRepository FoodCategories { get; }
        IFoodItemRepository FoodItems { get; }
        IFoodSuggestionRepository FoodSuggestions { get; }
        IRecipeRepository Recipes { get; }
        IMonthlyPlanRepository MonthlyPlans { get; }
        IWeightEntryRepository WeightEntries { get; }
        IMealItemRepository MealItems { get; }
    }
}
