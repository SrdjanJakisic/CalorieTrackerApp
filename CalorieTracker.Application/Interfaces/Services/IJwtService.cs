using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Application.Interfaces.Services
{
    public interface IJwtService
    {
        Task<(string token, DateTime expiresAt)> GenerateAccessToken(string userId, string email, string role);
        string GenerateRefreshToken();
    }
}
