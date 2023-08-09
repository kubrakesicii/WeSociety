using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Helpers;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;


namespace WeSociety.Application.CQRS.Commands.UserProfile.Create
{
    public class CreateUserProfileCommandHandler : ICommandHandler<CreateUserProfileCommand, Response>
    {
        private readonly IUnitOfWork _uow;

        public CreateUserProfileCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Response> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var bytearr = FileHelper.ConvertFileToByteArray(request.Image);

            Domain.Aggregates.UserProfileRoot.UserProfile newUserProfile = new Domain.Aggregates.UserProfileRoot.UserProfile(
                FileHelper.ConvertFileToByteArray(request.Image),
                request.FullName,
                request.Bio,
                request.UserId
                );

            await _uow.UserProfiles.Insert(newUserProfile);
            await _uow.SaveChangesAsync();
            return new SuccessResponse();
        }
    }
}
