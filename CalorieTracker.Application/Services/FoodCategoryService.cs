using CalorieTracker.Application.DTO.FoodCategory;
using CalorieTracker.Application.Interfaces.Services;
using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Application.Services
{
    public class FoodCategoryService : IFoodCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FoodCategoryService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        public async Task<FoodCategoryDto> CreateAsync(CreateFoodCategoryDto dto)
        {
            var foodCategory = new FoodCategory
            {
                Name = dto.Name,
                Description = dto.Description
            };

            await _unitOfWork.FoodCategories.CreateAsync(foodCategory);
            await _unitOfWork.SaveChangesAsync();

            return MapTo(foodCategory);
        }
        public async Task<IEnumerable<FoodCategoryDto>> GetAllAsync()
        {
            var categories = await _unitOfWork.FoodCategories.GetAllAsync();

            return categories.Select(x => MapTo(x));
        }
        public async Task<FoodCategoryDto> GetByIdAsync(int id)
        {
            var category = await _unitOfWork.FoodCategories.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Категорија са ID {id} не постоји!");

            return MapTo(category);
        }
        public async Task<FoodCategoryDto> UpdateAsync(int id, CreateFoodCategoryDto dto)
        {
            var category = await _unitOfWork.FoodCategories.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Категорија са ID {id} не постоји!");

            category.Name = dto.Name;
            category.Description = dto.Description;

            await _unitOfWork.FoodCategories.UpdateAsync(category);
            await _unitOfWork.SaveChangesAsync();

            return MapTo(category);
        }
        private FoodCategoryDto MapTo(FoodCategory category)
        {
            return new FoodCategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }
    }
}
