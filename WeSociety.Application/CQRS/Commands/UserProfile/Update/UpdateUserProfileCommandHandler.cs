using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.User;
using WeSociety.Application.Exceptions;
using WeSociety.Application.Helpers;
using WeSociety.Application.Interfaces;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.UserProfile.Update
{
    public class UpdateUserProfileCommandHandler : ICommandHandler<UpdateUserProfileCommand, DataResponse<GetUpdateUserDto>>
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

        public async Task<DataResponse<GetUpdateUserDto>> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
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


            return new SuccessDataResponse<GetUpdateUserDto>(returnDto);
        }
    }
}
