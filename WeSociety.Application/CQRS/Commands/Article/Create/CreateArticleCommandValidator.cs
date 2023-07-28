using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
