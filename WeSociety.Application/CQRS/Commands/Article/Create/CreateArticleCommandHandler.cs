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
        private readonly IAuthenticationService _authService;

        public CreateArticleCommandHandler(IUnitOfWork uow, IAuthenticationService authService)
        {
            _uow = uow;
            _authService = authService;
        }

        public async Task<Response> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            //var profileId = await _authService.GetProfileId();
            var userProfile = await _uow.UserProfiles.Get(x => x.Id == 1);
            var newArticle = userProfile.AddArticle(
                request.Title,
                request.Content,
                request.IsPublished,
                FileHelper.ConvertFileToByteArray(request.MainImage)
            );

            //await _uow.Articles.Insert(newArticle);
            await _uow.UserProfiles.Update(userProfile);
            await _uow.SaveChangesAsync();

            return new SuccessResponse();
        }
    }
}
