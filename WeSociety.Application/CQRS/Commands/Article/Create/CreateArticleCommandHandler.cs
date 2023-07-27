using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.Article.Create
{
    public class CreateArticleCommandHandler : ICommandHandler<CreateArticleCommand, Response>
    {
        private readonly IUnitOfWork _uow;

        public CreateArticleCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Response> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _uow.UserProfiles.Get(x => x.Id == request.UserProfileId);
            var newArticle = userProfile.AddArticle(request.Title, request.Content, request.IsPublished);

            //await _uow.Articles.Insert(newArticle);
            await _uow.UserProfiles.Update(userProfile);
            await _uow.SaveChangesAsync();

            return new SuccessResponse();
        }
    }
}
