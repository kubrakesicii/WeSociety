using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.ReadingList;

namespace WeSociety.Application.CQRS.Queries.ReadingList.GetAllByUser
{
    public class GetAllReadingListsByUserQuery : IQuery<List<GetReadingListDto>>
    {
        public int UserProfileId { get; set; }
    }
}
