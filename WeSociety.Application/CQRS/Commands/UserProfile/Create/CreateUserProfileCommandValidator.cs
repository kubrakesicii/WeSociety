using FluentValidation;

namespace WeSociety.Application.CQRS.Commands.UserProfile.Create
{
    public class CreateUserProfileCommandValidator : AbstractValidator<CreateUserProfileCommand>
    {
        public CreateUserProfileCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty();
            RuleFor(x => x.Bio).MaximumLength(200);
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(128);
        }
    }
}
