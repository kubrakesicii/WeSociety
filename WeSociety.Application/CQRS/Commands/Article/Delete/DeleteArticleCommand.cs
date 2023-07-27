using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Commands.Article.Delete
{
    public class DeleteArticleCommand : ICommand<Response>
    {
        public int Id { get; set; }
    }
}
