using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.ReadingList;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Queries.ReadingList.GetAllByUser
{
    public class GetAllReadingListsByUserQueryHandler : IQueryHandler<GetAllReadingListsByUserQuery, DataResponse<List<GetReadingListDto>>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllReadingListsByUserQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<DataResponse<List<GetReadingListDto>>> Handle(GetAllReadingListsByUserQuery request, CancellationToken cancellationToken)
        {
            var readingLists = await _uow.ReadingLists.GetAllReadingLists(request.UserProfileId);
            var dtoList = _mapper.Map<List<GetReadingListDto>>(readingLists);
            return new SuccessDataResponse<List<GetReadingListDto>>(dtoList);
        }
    }
}
