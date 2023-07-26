using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.UserProfile;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Queries.UserProfile.GetById
{
    public class GetUserProfileByIdQuery : IQuery<DataResponse<GetUserProfileDto>>
    {
        public int Id { get; set; }
    }
}
