using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Enums;
using CalorieTracker.Domain.Interfaces.Repositories;
using CalorieTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Infrastructure.Repositories
{
    public class FoodSuggestionRepository : IFoodSuggestionRepository
    {
        private readonly AppDbContext _db;
        public FoodSuggestionRepository(AppDbContext db) => _db = db;
        public async Task CreateAsync(FoodSuggestion suggestion) => await _db.FoodSuggestions.AddAsync(suggestion);
        public Task<bool> ExistsAsync(string name, string? manufacturer) => _db.FoodSuggestions.AnyAsync(x => x.Name == name && x.Manufacturer == manufacturer);
        public async Task<IEnumerable<FoodSuggestion>> GetAllAsync(SuggestionStatus? status)
        {
            var query = _db.FoodSuggestions.AsQueryable();

            if(status.HasValue)
            {
                query = query.Where(x => x.Status == status.Value);
            }

            return await query.ToListAsync();
        }
        public async Task<FoodSuggestion?> GetByIdAsync(int id) => await _db.FoodSuggestions.FindAsync(id);
        public Task UpdateAsync(FoodSuggestion suggestion)
        {
            _db.FoodSuggestions.Update(suggestion);
            return Task.CompletedTask;
        }
    }
}
