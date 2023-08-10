using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.ArticleComment.Create
{
    public class CreateArticleCommentCommandHandler : ICommandHandler<CreateArticleCommentCommand, Response>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateArticleCommentCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Response> Handle(CreateArticleCommentCommand request, CancellationToken cancellationToken)
        {
            var article = await _uow.Articles.Get(x => x.Id == request.ArticleId);
            article.AddComment(request.UserProfileId, request.Text);

            await _uow.SaveChangesAsync();
            return new SuccessResponse();
        }
    }
}
