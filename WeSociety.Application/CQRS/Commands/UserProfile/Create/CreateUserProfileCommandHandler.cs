using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Helpers;
using WeSociety.Application.Responses;
using WeSociety.Domain.AggregateRoots.UserProfile.Entities;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.UserProfile.Create
{
    public class CreateUserProfileCommandHandler : ICommandHandler<CreateUserProfileCommand, Response>
    {
        private readonly IUnitOfWork _uow;

        public async Task<Response> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            Domain.AggregateRoots.UserProfile.UserProfile newUserProfile = new Domain.AggregateRoots.UserProfile.UserProfile(
                await FileHelper.ConvertFileToByteArray(request.Image),
                request.FullName,
                request.Bio,
                request.UserId,
                new List<Article> { },
                new List<FollowRelationship> { },
                new List<FollowRelationship> { }
                );


        }
    }
}
