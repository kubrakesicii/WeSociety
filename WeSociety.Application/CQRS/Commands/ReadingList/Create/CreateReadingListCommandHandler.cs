using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.ReadingList.Create
{
    public class CreateReadingListCommandHandler : ICommandHandler<CreateReadingListCommand, Response>
    {
        private readonly IUnitOfWork _uow;

        public CreateReadingListCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Response> Handle(CreateReadingListCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _uow.UserProfiles.Get(x => x.Id == request.UserProfileId);
            userProfile.AddReadingList(request.Name);

            await _uow.SaveChangesAsync();
            return new SuccessResponse();
        }
    }
}
