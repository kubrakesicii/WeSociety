using AutoMapper;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.ArticleClap;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Queries.ArticleClap.GetAllByArticle
{
    public class GetAllClappingUsersQueryHandler : IQueryHandler<GetAllClappingUsersQuery, List<GetClapUserDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllClappingUsersQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<GetClapUserDto>> Handle(GetAllClappingUsersQuery request, CancellationToken cancellationToken)
        {
            var claps = await _uow.ArticleClaps.GetAllByArticleWithUser(request.ArticleId);

            var groupedClaps = claps.GroupBy(x => x.UserProfile).Select(g => new GetClapUserGroupDto
            {
                Count = g.Count(),
                UserProfile = g.Key
            }).ToList();

            var clapUserDto = _mapper.Map<List<GetClapUserDto>>(groupedClaps);
            return clapUserDto;
        }
    }
}
