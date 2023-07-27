using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.Article.Update
{
    public class UpdateArticleCommandHandler : ICommandHandler<UpdateArticleCommand, Response>
    {
        private readonly IUnitOfWork _uow;

        public UpdateArticleCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Task<Response> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
        }
    }
}
