using CalorieTracker.Application.DTO.Auth;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Application.Validators.Auth
{
    public class LoginValidator:AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
