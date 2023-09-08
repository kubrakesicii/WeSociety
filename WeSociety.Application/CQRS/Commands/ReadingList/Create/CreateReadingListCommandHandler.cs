using MediatR;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.ReadingList.Create
{
    public class CreateReadingListCommandHandler : ICommandHandler<CreateReadingListCommand, Unit>
    {
        private readonly IUnitOfWork _uow;

        public CreateReadingListCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(CreateReadingListCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _uow.UserProfiles.Get(x => x.Id == request.UserProfileId);
            userProfile.AddReadingList(request.Name);
            return await Task.FromResult(Unit.Value);
        }
    }
}
