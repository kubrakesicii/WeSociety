using FluentValidation;

namespace WeSociety.Application.CQRS.Commands.Auth.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().MaximumLength(128);
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
