using CalorieTracker.Application.DTO.Auth;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Application.Validators.Auth
{
    public class RegisterValidator:AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
            RuleFor(x => x.ConfirmPassword).NotEmpty().Equal(x => x.Password).WithMessage("Лозинке се не поклапају!");
        }
    }
}
