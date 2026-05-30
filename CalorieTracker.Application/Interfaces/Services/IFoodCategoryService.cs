using CalorieTracker.Application.DTO.FoodCategory;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Application.Interfaces.Services
{
    public interface IFoodCategoryService
    {
        Task<IEnumerable<FoodCategoryDto>> GetAllAsync();
        Task<FoodCategoryDto> GetByIdAsync(int id);
        Task CreateAsync(CreateFoodCategoryDto dto);
        Task<FoodCategoryDto> UpdateAsync(int id, CreateFoodCategoryDto dto);
    }
}
