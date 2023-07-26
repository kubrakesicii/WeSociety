using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Commands.UserProfile.Create
{
    public class CreateUserProfileCommandHandler : ICommandHandler<CreateUserProfileCommand, Response>
    {
        public Task<Response> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
           throw new NotImplementedException();
        }
    }
}
