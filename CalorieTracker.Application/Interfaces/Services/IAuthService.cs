using CalorieTracker.Application.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDto dto);
        Task<AuthResponseDto> LoginAsync(LoginDto dto);
        Task<AuthResponseDto> RefreshAsync(string refreshToken);
        Task revokeAsync(string userId);
    }
}
