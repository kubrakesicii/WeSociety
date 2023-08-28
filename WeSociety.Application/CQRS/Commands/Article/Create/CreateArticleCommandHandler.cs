using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Helpers;
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
            //var profileId = await _authService.GetProfileId();
            var userProfile = await _uow.UserProfiles.Get(x => x.Id == request.UserProfileId);
            var newArticle = userProfile.AddArticle(
                request.Title,
                request.Content,
                request.IsPublished,
                request.CategoryId,
                request.MainImage == null ? null : FileHelper.ConvertFileToByteArray(request.MainImage)
            );

            //await _uow.Articles.Insert(newArticle);
            await _uow.UserProfiles.Update(userProfile);

            return new SuccessResponse();
        }
    }
}
