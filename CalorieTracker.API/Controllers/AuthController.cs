using CalorieTracker.Application.DTO.Auth;
using CalorieTracker.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CalorieTracker.API.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto) 
        {
            await _authService.RegisterAsync(registerDto);
            return Ok("Регистрација је успешна!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto) 
        {
            var response = await _authService.LoginAsync(loginDto);
            return Ok(response);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] string refresh) 
        {
            var response = await _authService.RefreshAsync(refresh);
            return Ok(response);
        }

        [HttpPost("revoke")]
        [Authorize]
        public async Task<IActionResult> Revoke() 
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _authService.RevokeAsync(userId!);
            return NoContent();
        }
    }
}
