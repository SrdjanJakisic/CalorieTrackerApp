using CalorieTracker.Application.DTO.Auth;

namespace CalorieTracker.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDto dto);
        Task<AuthResponseDto> LoginAsync(LoginDto dto);
        Task<AuthResponseDto> RefreshAsync(string refreshToken);
        Task RevokeAsync(string userId);
    }
}
