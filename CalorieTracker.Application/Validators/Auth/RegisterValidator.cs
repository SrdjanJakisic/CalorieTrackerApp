using CalorieTracker.Application.DTO.Auth;
using FluentValidation;

namespace CalorieTracker.Application.Validators.Auth
{
    public class RegisterValidator:AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email је обавезан")
                .EmailAddress().WithMessage("Email мора бити у исправном формату!");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Лозинка је обавезна")
                .MinimumLength(6).WithMessage("Лозинка мора имати најмање 6 знакова!");
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Потврда лозинке је обавезна!")
                .Equal(x => x.Password).WithMessage("Лозинке се не поклапају!");
        }
    }
}
