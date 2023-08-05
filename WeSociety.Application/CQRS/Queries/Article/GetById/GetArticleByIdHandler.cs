using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Article;
using WeSociety.Application.Exceptions;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Queries.Article.GetById
{
    public class GetArticleByIdHandler : IQueryHandler<GetArticleByIdQuery, DataResponse<GetArticleDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetArticleByIdHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<DataResponse<GetArticleDto>> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var article = await _uow.Articles.GetByIdWithIncludes(request.Id);
            if (article == null) throw new NotfoundException();
            var artDto = _mapper.Map<GetArticleDto>(article);

            article.IncreaseViewCount();
            await _uow.SaveChangesAsync();
            return new SuccessDataResponse<GetArticleDto>(artDto);
        }
    }
}
