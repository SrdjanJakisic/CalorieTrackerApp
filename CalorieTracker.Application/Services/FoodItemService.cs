using CalorieTracker.Application.DTO.FoodItem;
using CalorieTracker.Application.Interfaces.Services;
using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Application.Services
{
    public class FoodItemService : IFoodItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodItemService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        public async Task<FoodItemDto> CreateAsync(CreateFoodItemDto dto)
        {
            var item = new FoodItem
            {
                CategoryId = dto.CategoryId,
                Name = dto.Name,
                Manufacturer = dto.Manufacturer,
                CaloriesPer100g = dto.CaloriesPer100g,
                ProteinPer100g = dto.ProteinPer100g,
                CarbsPer100g = dto.CarbsPer100g,
                FatPer100g = dto.FatPer100g,
                IsLenten = dto.IsLenten,
                AdditionalInfo = dto.AdditionalInfo,
                Source = dto.Source,
                IsApproved = true
            };

            await _unitOfWork.FoodItems.CreateAsync(item);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(item);
        }
        public async Task DeleteAsync(int id)
        {
            var item = await _unitOfWork.FoodItems.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Намирница са ID {id} не постоји!");

            await _unitOfWork.FoodItems.DeleteAsync(item);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<IEnumerable<FoodItemSummaryDto>> GetAllAsync(string? search, int? categoryId, bool? lenten, bool? isApproved)
        {
            var items = await _unitOfWork.FoodItems.GetAllAsync(search, categoryId, lenten, isApproved);

            return items.Select(item => new FoodItemSummaryDto
            {
                Id = item.Id,
                Name = item.Name,
                Manufacturer = item.Manufacturer,
                CategoryName = item.Category?.Name ?? string.Empty,
                CaloriesPer100g = item.CaloriesPer100g,
                IsLenten = item.IsLenten,
                ImageUrl = item.ImageUrl
            });
        }
        public async Task<FoodItemDto> GetByIdAsync(int id)
        {
            var item = await _unitOfWork.FoodItems.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Намирница са ID {id} не постоји!");

            return MapToDto(item);
        }
        public async Task SetImageUrlAsync(int id, string imageUrl)
        {
            var item = await _unitOfWork.FoodItems.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Намирница са ID {id} не постоји!");

            item.ImageUrl = imageUrl;
            await _unitOfWork.FoodItems.UpdateAsync(item);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<FoodItemDto> UpdateAsync(int id, UpdateFoodItemDto dto)
        {
            var item = await _unitOfWork.FoodItems.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Намирница са ID {id} не постоји!");

            item.CategoryId = dto.CategoryId;
            item.Name = dto.Name;
            item.Manufacturer = dto.Manufacturer;
            item.CaloriesPer100g = dto.CaloriesPer100g;
            item.ProteinPer100g = dto.ProteinPer100g;
            item.CarbsPer100g = dto.CarbsPer100g;
            item.FatPer100g = dto.FatPer100g;
            item.IsLenten = dto.IsLenten;
            item.IsApproved = dto.IsApproved;
            item.Source = dto.Source;
            item.AdditionalInfo = dto.AdditionalInfo;

            await _unitOfWork.FoodItems.UpdateAsync(item);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(item);
        }
        private FoodItemDto MapToDto(FoodItem item)
        {
            return new FoodItemDto
            {
                Id = item.Id,
                CategoryId = item.CategoryId,
                CategoryName = item.Category?.Name ?? string.Empty,
                Name = item.Name,
                Manufacturer = item.Manufacturer,
                CaloriesPer100g = item.CaloriesPer100g,
                ProteinPer100g = item.ProteinPer100g,
                CarbsPer100g = item.CarbsPer100g,
                FatPer100g = item.FatPer100g,
                IsLenten = item.IsLenten,
                IsApproved = item.IsApproved,
                AdditionalInfo = item.AdditionalInfo,
                Source = item.Source,
                ImageUrl = item.ImageUrl
            };
        }
    }
}
