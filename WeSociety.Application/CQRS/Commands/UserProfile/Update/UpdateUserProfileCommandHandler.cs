using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Exceptions;
using WeSociety.Application.Helpers;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.UserProfile.Update
{
    public class UpdateUserProfileCommandHandler : ICommandHandler<UpdateUserProfileCommand, Response>
    {
        private readonly IUnitOfWork _uow;

        public UpdateUserProfileCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Response> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = await _uow.UserProfiles.Get(x => x.Id ==  request.Id);
            if (profile == null) throw new NotfoundException();

            profile.Update(
                FileHelper.ConvertFileToByteArray(request.Image),
                request.FullName,
                request.Bio);
            await _uow.UserProfiles.Update(profile);
            await _uow.SaveChangesAsync();
            return new SuccessResponse();
        }
    }
}
