using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Category;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Queries.Category.GetAll
{
    public class GetAllCategoriesQuery : IQuery<DataResponse<List<GetCategoryDto>>
    {
    }
}
