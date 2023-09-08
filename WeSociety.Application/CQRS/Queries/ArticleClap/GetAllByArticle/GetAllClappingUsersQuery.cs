using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.ArticleClap;

namespace WeSociety.Application.CQRS.Queries.ArticleClap.GetAllByArticle
{
    public class GetAllClappingUsersQuery : IQuery<List<GetClapUserDto>>
    {
        public int ArticleId { get; set; }
    }
}
