using CalorieTracker.Application.DTO.FoodCategory;

namespace CalorieTracker.Application.Interfaces.Services
{
    public interface IFoodCategoryService
    {
        Task<IEnumerable<FoodCategoryDto>> GetAllAsync();
        Task<FoodCategoryDto> GetByIdAsync(int id);
        Task<FoodCategoryDto> CreateAsync(CreateFoodCategoryDto dto);
        Task<FoodCategoryDto> UpdateAsync(int id, CreateFoodCategoryDto dto);
    }
}
