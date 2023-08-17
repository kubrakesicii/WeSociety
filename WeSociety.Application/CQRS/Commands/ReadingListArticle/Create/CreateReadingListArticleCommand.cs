using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Commands.ReadingListArticle.Create
{
    public class CreateReadingListArticleCommand : ICommand<Response>
    {
        public int ReadingListId { get; set; }
        public int ArticleId { get; set; }
    }
}
