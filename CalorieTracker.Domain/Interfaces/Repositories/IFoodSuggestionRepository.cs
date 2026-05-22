using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Domain.Interfaces.Repositories
{
    public interface IFoodSuggestionRepository
    {
        Task<IEnumerable<FoodSuggestion>> GetAllAsync(SuggestionStatus? status);
        Task<FoodSuggestion> GetById(int id);
        Task CreateAsync(FoodSuggestion suggestion);
        Task UpdateAsync(FoodSuggestion suggestion);
    }
}
