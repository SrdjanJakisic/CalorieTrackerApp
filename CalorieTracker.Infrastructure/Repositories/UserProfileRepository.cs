using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Interfaces.Repositories;
using CalorieTracker.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Infrastructure.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly AppDbContext _db;
        public UserProfileRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(UserProfile profile)
        {
            await _db.UserProfiles.AddAsync(profile);
        }

        public async Task<UserProfile?> GetByUserIdAsync(string userId)
        {
            return await _db.UserProfiles.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task UpdateAsync(UserProfile profile)
        {
            _db.UserProfiles.Update(profile);
        }
    }
}
