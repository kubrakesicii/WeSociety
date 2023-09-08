﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.ReadingListArticle.Delete
{
    public class DeleteReadingListArticleCommandHandler : ICommandHandler<DeleteReadingListArticleCommand, Unit>
    {
        private readonly IUnitOfWork _uow;

        public DeleteReadingListArticleCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(DeleteReadingListArticleCommand request, CancellationToken cancellationToken)
        {
            var readingListArt = await _uow.ReadingListArticles.Get(x => x.Id == request.Id);
            await _uow.ReadingListArticles.Delete(readingListArt);
            return await Task.FromResult(Unit.Value);
        }
    }
}
