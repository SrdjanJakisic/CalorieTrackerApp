using CalorieTracker.Application.DTO.FoodSuggestion;
using CalorieTracker.Application.Interfaces.Services;
using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Enums;
using CalorieTracker.Domain.Interfaces;
using CalorieTracker.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

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
                CaloriesPer100g = suggestion.CaloriesPer100g,
                ProteinPer100g = suggestion.ProteinPer100g,
                CarbsPer100g = suggestion.CarbsPer100g,
                FatPer100g = suggestion.FatPer100g,
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
                Manufacturer = dto.Manufacturer,
                CategoryId = dto.CategoryId,
                CaloriesPer100g = dto.CaloriesPer100g,
                ProteinPer100g = dto.ProteinPer100g,
                CarbsPer100g = dto.CarbsPer100g,
                FatPer100g = dto.FatPer100g,
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
                CaloriesPer100g = suggestion.CaloriesPer100g,
                ProteinPer100g = suggestion.ProteinPer100g,
                CarbsPer100g = suggestion.CarbsPer100g,
                FatPer100g = suggestion.FatPer100g,
                IsLenten = suggestion.IsLenten,
                Status = suggestion.Status,
                AdminNote = suggestion.AdminNote
            };
        }
    }
}
