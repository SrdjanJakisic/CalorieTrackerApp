using CalorieTracker.Domain.Entities;

namespace CalorieTracker.Domain.Interfaces.Repositories
{
    public interface IUserProfileRepository
    {
        Task<UserProfile?>GetByUserIdAsync(string userId);
        Task CreateAsync(UserProfile profile);
        Task UpdateAsync(UserProfile profile);
    }
}
