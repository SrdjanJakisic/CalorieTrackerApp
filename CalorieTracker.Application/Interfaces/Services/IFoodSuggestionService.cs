using CalorieTracker.Application.DTO.FoodSuggestion;
using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Application.Interfaces.Services
{
    public interface IFoodSuggestionService
    {
        Task CreateAsync(string userId, CreateFoodSuggestionDto dto);
        Task<IEnumerable<FoodSuggestionDto>> GetAllAsync(SuggestionStatus? status);
        Task ApproveAsync(int id);
        Task RejectAsync(int id, string? adminNote);
    }
}
