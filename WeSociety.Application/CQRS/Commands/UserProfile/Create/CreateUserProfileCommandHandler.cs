using MediatR;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Core.Helpers;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.UserProfile.Create
{
    public class CreateUserProfileCommandHandler : ICommandHandler<CreateUserProfileCommand, Unit>
    {
        private readonly IUnitOfWork _uow;

        public CreateUserProfileCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            Domain.Aggregates.UserProfileRoot.UserProfile newUserProfile = new Domain.Aggregates.UserProfileRoot.UserProfile(
                FileHelper.ConvertFileToByteArray(request.Image),
                request.FullName,
                request.Bio,
                request.Github,
                request.Linkedin,
                request.UserId
                );

            await _uow.UserProfiles.InsertAsync(newUserProfile,cancellationToken);
            return await Task.FromResult(Unit.Value);
        }
    }
}
