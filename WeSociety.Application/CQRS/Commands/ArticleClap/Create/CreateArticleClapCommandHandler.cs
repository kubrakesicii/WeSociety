using MediatR;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.ArticleClap.Create
{
    public class CreateArticleClapCommandHandler : ICommandHandler<CreateArticleClapCommand, Unit>
    {
        private readonly IUnitOfWork _uow;

        public CreateArticleClapCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(CreateArticleClapCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _uow.UserProfiles.Get(x => x.Id == request.UserProfileId);
            userProfile.ClapArticle(request.ArticleId);
            return await Task.FromResult(Unit.Value);
        }

    }
}
