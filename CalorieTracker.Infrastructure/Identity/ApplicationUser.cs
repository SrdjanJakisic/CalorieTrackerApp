using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiry { get; set; }

    }
}
