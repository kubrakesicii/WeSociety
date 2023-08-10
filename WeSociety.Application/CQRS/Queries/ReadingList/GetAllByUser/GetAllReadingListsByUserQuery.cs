using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.ReadingList;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Queries.ReadingList.GetAllByUser
{
    public class GetAllReadingListsByUserQuery : IQuery<DataResponse<List<GetReadingListDto>>>
    {
        public int UserProfileId { get; set; }
    }
}
