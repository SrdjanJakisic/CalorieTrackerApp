using CalorieTracker.Application.DTO.FoodItem;

namespace CalorieTracker.Application.Interfaces.Services
{
    public interface IFoodItemService
    {
        Task<IEnumerable<FoodItemSummaryDto>> GetAllAsync(string? search, int? categoryId, bool? lenten, bool? isApproved);
        Task<FoodItemDto> GetByIdAsync(int id);
        Task<FoodItemDto> CreateAsync(CreateFoodItemDto dto);
        Task<FoodItemDto> UpdateAsync(int id, UpdateFoodItemDto dto);
        Task DeleteAsync(int id);
        Task SetImageUrlAsync(int id, string imageUrl);
    }
}
