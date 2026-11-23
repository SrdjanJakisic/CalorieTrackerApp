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
        IWeightEntryRepository WeightEntries { get; }
        IDayRepository Days { get; }
        IFoodLogEntryRepository FoodLogEntries { get; }
    }
}
