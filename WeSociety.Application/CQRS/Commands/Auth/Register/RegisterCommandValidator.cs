﻿using FluentValidation;

namespace WeSociety.Application.CQRS.Commands.Auth.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator() {
            RuleFor(x => x.Email).NotEmpty().MaximumLength(128);
            RuleFor(x => x.Password).NotEmpty().MaximumLength(15).MinimumLength(3);
            RuleFor(x => x.UserName).NotEmpty().MaximumLength(128);
        }
    }
}
