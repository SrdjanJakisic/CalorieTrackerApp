using CalorieTracker.Application.DTO.FoodItem;
using CalorieTracker.Application.Interfaces.Services;
using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Interfaces;

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
                Manufacturer = string.IsNullOrWhiteSpace(dto.Manufacturer) ? null : dto.Manufacturer,
                Unit = dto.Unit,
                AmountPerPiece = dto.AmountPerPiece,
                Calories = dto.Calories,
                Protein = dto.Protein,
                Carbs = dto.Carbs,
                Fat = dto.Fat,
                IsLenten = dto.IsLenten,
                AdditionalInfo = dto.AdditionalInfo,
                Source = dto.Source,
                IsApproved = true
            };

            await _unitOfWork.FoodItems.CreateAsync(item);
            await _unitOfWork.SaveChangesAsync();

            var created = await _unitOfWork.FoodItems.GetByIdAsync(item.Id)
                ?? throw new InvalidOperationException("Намирница није креирана!");

            return MapToDto(created);
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
                Unit = item.Unit,
                CategoryName = item.Category?.Name ?? string.Empty,
                Calories = item.Calories,
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
            item.Manufacturer = string.IsNullOrWhiteSpace(dto.Manufacturer) ? null : dto.Manufacturer;
            item.Unit = dto.Unit;
            item.AmountPerPiece = dto.AmountPerPiece;
            item.Calories = dto.Calories;
            item.Protein = dto.Protein;
            item.Carbs = dto.Carbs;
            item.Fat = dto.Fat;
            item.IsLenten = dto.IsLenten;
            item.IsApproved = dto.IsApproved;
            item.Source = dto.Source;
            item.AdditionalInfo = dto.AdditionalInfo;

            await _unitOfWork.FoodItems.UpdateAsync(item);
            await _unitOfWork.SaveChangesAsync();

            var updated = await _unitOfWork.FoodItems.GetByIdAsync(item.Id)
                ?? throw new InvalidOperationException("Намирница није ажурирана!");

            return MapToDto(updated);
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
                Unit = item.Unit,
                AmountPerPiece = item.AmountPerPiece,
                Calories = item.Calories,
                Protein = item.Protein,
                Carbs = item.Carbs,
                Fat = item.Fat,
                IsLenten = item.IsLenten,
                IsApproved = item.IsApproved,
                AdditionalInfo = item.AdditionalInfo,
                Source = item.Source,
                ImageUrl = item.ImageUrl
            };
        }
    }
}
