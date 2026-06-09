using CalorieTracker.Application.DTO.FoodSuggestion;
using CalorieTracker.Application.Interfaces.Services;
using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Enums;
using CalorieTracker.Domain.Interfaces;

namespace CalorieTracker.Application.Services
{
    public class FoodSuggestionService : IFoodSuggestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodSuggestionService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        public async Task ApproveAsync(int id)
        {
            var suggestion = await _unitOfWork.FoodSuggestions.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Предлог не постоји!");

            if (suggestion.Status != SuggestionStatus.Pending)
                throw new ArgumentException("Предлог је већ обрађен!");

            suggestion.Status = SuggestionStatus.Approved;
            await _unitOfWork.FoodSuggestions.UpdateAsync(suggestion);

            var item = new FoodItem
            {
                CategoryId = suggestion.CategoryId,
                Name = suggestion.Name,
                Manufacturer = suggestion.Manufacturer,
                Unit = suggestion.Unit,
                AmountPerPiece = suggestion.AmountPerPiece,
                Calories = suggestion.Calories,
                Protein = suggestion.Protein,
                Carbs = suggestion.Carbs,
                Fat = suggestion.Fat,
                IsLenten = suggestion.IsLenten,
                IsApproved = true
            };

            await _unitOfWork.FoodItems.CreateAsync(item);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task CreateAsync(string userId, CreateFoodSuggestionDto dto)
        {
            var suggestion = new FoodSuggestion
            {
                UserId = userId,
                Name = dto.Name,
                Manufacturer = string.IsNullOrWhiteSpace(dto.Manufacturer) ? null : dto.Manufacturer,
                CategoryId = dto.CategoryId,
                Unit = dto.Unit,
                AmountPerPiece = dto.AmountPerPiece,
                Calories = dto.Calories,
                Protein = dto.Protein,
                Carbs = dto.Carbs,
                Fat = dto.Fat,
                IsLenten = dto.IsLenten,
                Status = SuggestionStatus.Pending,
                AdminNote = null
            };

            await _unitOfWork.FoodSuggestions.CreateAsync(suggestion);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<IEnumerable<FoodSuggestionDto>> GetAllAsync(SuggestionStatus? status)
        {
            var suggestion = await _unitOfWork.FoodSuggestions.GetAllAsync(status);
            return suggestion.Select(x => MapToDto(x));

        }
        public async Task RejectAsync(int id, string? adminNote)
        {
            var suggestion = await _unitOfWork.FoodSuggestions.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Предлог не постоји!");

            if (suggestion.Status != SuggestionStatus.Pending)
                throw new ArgumentException("Предлог је већ обрађен!");

            suggestion.Status = SuggestionStatus.Rejected;
            suggestion.AdminNote = adminNote;

            await _unitOfWork.FoodSuggestions.UpdateAsync(suggestion);
            await _unitOfWork.SaveChangesAsync();
        }
        private FoodSuggestionDto MapToDto(FoodSuggestion suggestion)
        {
            return new FoodSuggestionDto
            {
                Id = suggestion.Id,
                UserId = suggestion.UserId,
                Name = suggestion.Name,
                Manufacturer = suggestion.Manufacturer,
                CategoryId = suggestion.CategoryId,
                Unit = suggestion.Unit,
                AmountPerPiece = suggestion.AmountPerPiece,
                Calories = suggestion.Calories,
                Protein = suggestion.Protein,
                Carbs = suggestion.Carbs,
                Fat = suggestion.Fat,
                IsLenten = suggestion.IsLenten,
                Status = suggestion.Status,
                AdminNote = suggestion.AdminNote
            };
        }
    }
}
