using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Commands.ArticleComment.Create
{
    public class CreateArticleCommentCommand : ICommand<Response>
    {
        public int ArticleId { get; set; }
        public int UserProfileId { get; set; }   //Current user idsi alınacak
        public string Text { get; set; }
    }
}
