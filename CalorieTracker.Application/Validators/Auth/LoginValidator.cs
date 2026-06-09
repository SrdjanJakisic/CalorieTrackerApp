using CalorieTracker.Application.DTO.Auth;
using FluentValidation;

namespace CalorieTracker.Application.Validators.Auth
{
    public class LoginValidator:AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email је обавезан!");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Лозинка је обавезна!");
        }
    }
}
