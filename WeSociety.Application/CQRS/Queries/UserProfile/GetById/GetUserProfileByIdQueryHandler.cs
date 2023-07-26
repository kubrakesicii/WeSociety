using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.UserProfile;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Queries.UserProfile.GetById
{
    public class GetUserProfileByIdQueryHandler : IQueryHandler<GetUserProfileByIdQuery, DataResponse<GetUserProfileDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetUserProfileByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<DataResponse<GetUserProfileDto>> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var userProfile = await _uow.UserProfiles.GetWithUserAsync(request.Id);
            return new SuccessDataResponse<GetUserProfileDto>(_mapper.Map<GetUserProfileDto>(userProfile));
        }
    }
}
