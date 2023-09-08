using FluentValidation;

namespace WeSociety.Application.CQRS.Commands.Article.Create
{
    public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(128);
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.IsPublished).NotNull();
        }
    }
}
