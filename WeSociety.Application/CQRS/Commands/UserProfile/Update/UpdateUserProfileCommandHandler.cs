﻿using AutoMapper;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.User;
using WeSociety.Application.Interfaces;
using WeSociety.Core.Exceptions;
using WeSociety.Core.Helpers;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.UserProfile.Update
{
    public class UpdateUserProfileCommandHandler : ICommandHandler<UpdateUserProfileCommand, GetUpdateUserDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IElasticSearchService<Domain.Aggregates.UserProfileRoot.UserProfile> _elasticSearchService;

        public UpdateUserProfileCommandHandler(IUnitOfWork uow, IMapper mapper, 
            IElasticSearchService<Domain.Aggregates.UserProfileRoot.UserProfile> elasticSearchService)
        {
            _uow = uow;
            _mapper = mapper;
            _elasticSearchService = elasticSearchService;
        }

        public async Task<GetUpdateUserDto> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = await _uow.UserProfiles.GetWithUserAsync(request.id);
            if (profile == null) throw new NotfoundException();

            profile.Update(
                request.Image == null ? null : FileHelper.ConvertFileToByteArray(request.Image),
                request.FullName,
                request.Bio,
                request.Github,
                request.Linkedin);
            await _uow.UserProfiles.Update(profile);
            var returnDto = _mapper.Map<GetUpdateUserDto>(profile);


            //ELK UPDATE
            //await _elasticSearchService.AddOrUpdateAsync("users",profile.UserId,
            //    new Domain.Aggregates.UserProfileRoot.UserProfile(profile.Id,profile.FullName, profile.Bio));

            return returnDto;
        }
    }
}
