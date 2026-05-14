using CalorieTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Domain.Interfaces.Repositories
{
    public interface IUserProfileRepository
    {
        Task<UserProfile?>GetByUserIdAsync(string userId);
        Task CreateAsync(UserProfile profile);
        Task UpdateAsync(UserProfile profile);
    }
}
