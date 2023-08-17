using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.ArticleClap;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Queries.ArticleClap.GetAllByArticle
{
    public class GetAllClappingUsersQueryHandler : IQueryHandler<GetAllClappingUsersQuery, DataResponse<List<GetClapUserDto>>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllClappingUsersQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<DataResponse<List<GetClapUserDto>>> Handle(GetAllClappingUsersQuery request, CancellationToken cancellationToken)
        {
            var claps = await _uow.ArticleClaps.GetAllByArticleWithUser(request.ArticleId);

            var groupedClaps = claps.GroupBy(x => x.UserProfile).Select(g => new GetClapUserGroupDto
            {
                Count = g.Count(),
                UserProfile = g.Key
            }).ToList();

            var clapUserDto = _mapper.Map<List<GetClapUserDto>>(groupedClaps);
            return new SuccessDataResponse<List<GetClapUserDto>>(clapUserDto);
        }
    }
}
