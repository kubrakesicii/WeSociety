using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Commands.Article.Create
{
    public class CreateArticleCommand : ICommand<Response>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int IsPublished { get; set; }
        public int UserProfileId { get; set; }
    }
}
