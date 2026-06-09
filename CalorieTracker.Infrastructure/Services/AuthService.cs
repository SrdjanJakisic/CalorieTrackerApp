using CalorieTracker.Application.DTO.Auth;
using CalorieTracker.Application.Interfaces.Services;
using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Interfaces;
using CalorieTracker.Domain.Interfaces.Repositories;
using CalorieTracker.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtService _jwtService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserProfileRepository _userProfilRepo;

        public AuthService(UserManager<ApplicationUser> userManager,IJwtService jwtService, IUnitOfWork unitOfWork, IUserProfileRepository userPorfileRepo)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _unitOfWork = unitOfWork;
            _userProfilRepo = userPorfileRepo;
        }
        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null) throw new UnauthorizedAccessException("Погрешан емаил или лозинка!");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, dto.Password);

            if (!isPasswordValid) throw new UnauthorizedAccessException("Погрешан email или лозинка!");

            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault() ?? "User";

            var refreshToken = _jwtService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);

            await _userManager.UpdateAsync(user);

            var (accessToken, expiresAt) = await _jwtService.GenerateAccessToken(user.Id, user.Email!, role);

            return new AuthResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresAt = expiresAt
            };

        }
        public async Task<AuthResponseDto> RefreshAsync(string refreshToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);

            if (user == null) throw new UnauthorizedAccessException("Неважећи refresh токен!");
            if (user.RefreshTokenExpiry < DateTime.UtcNow) throw new UnauthorizedAccessException("Refresh токен је истекао!");

            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault() ?? "User";

            var newRefreshToken = _jwtService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);

            await _userManager.UpdateAsync(user);

            var (newAccessToken, expiresAt) = await _jwtService.GenerateAccessToken(user.Id, user.Email!, role);

            return new AuthResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
                ExpiresAt = expiresAt
            };



        }
        public async Task RegisterAsync(RegisterDto dto)
        {
            var user = new ApplicationUser
            {
                Email = dto.Email,
                UserName = dto.Email
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if(!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new ArgumentException(errors);
            }

            await _userManager.AddToRoleAsync(user, "User");

            var profile = new UserProfile
            {
                UserId = user.Id,
                CalorieGoal = 0,
                ProteinGoal = 0
            };

            await _userProfilRepo.CreateAsync(profile);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task RevokeAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null) throw new UnauthorizedAccessException("Корисник не постоји!");

            user.RefreshToken = null;
            user.RefreshTokenExpiry = null;

            await _userManager.UpdateAsync(user);
        }
    }
}
