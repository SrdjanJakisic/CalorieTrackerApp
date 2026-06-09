using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Interfaces.Repositories;
using CalorieTracker.Infrastructure.Data;

namespace CalorieTracker.Infrastructure.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly AppDbContext _db;
        public UserProfileRepository(AppDbContext db) => _db = db;
        public async Task CreateAsync(UserProfile profile) => await _db.UserProfiles.AddAsync(profile);
        public async Task<UserProfile?> GetByUserIdAsync(string userId) 
            => await _db.UserProfiles.FindAsync(userId);
        public  Task UpdateAsync(UserProfile profile)
        {
            _db.UserProfiles.Update(profile);
            return Task.CompletedTask;
        }
    }
}
