﻿using MediatR;
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
