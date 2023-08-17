using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.ArticleClap.Create
{
    public class CreateArticleClapCommandHandler : ICommandHandler<CreateArticleClapCommand, Response>
    {
        private readonly IUnitOfWork _uow;

        public CreateArticleClapCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Response> Handle(CreateArticleClapCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _uow.UserProfiles.Get(x => x.Id == request.UserProfileId);
            userProfile.ClapArticle(request.ArticleId);

            await _uow.SaveChangesAsync();
            return new SuccessResponse();
        }
    }
}
