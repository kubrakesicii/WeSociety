using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Commands.ArticleClap.Create
{
    public class CreateArticleClapCommand : ICommand<Response>
    {
        public int UserProfileId { get; set; }
        public int ArticleId { get; set; }
    }
}
