using MediatR;
using Microsoft.EntityFrameworkCore;
using Nest;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Core.Exceptions;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.Decorators
{
    public class CommandHandlerDecorator<TCommand, TResponse> : ICommandHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
    {
        private readonly ICommandHandler<TCommand, TResponse> _commandHandler;
        private readonly IUnitOfWork _uow;
        public CommandHandlerDecorator(ICommandHandler<TCommand, TResponse> commandHandler, IUnitOfWork uow)
        {
            _commandHandler = commandHandler;
            _uow = uow;
        }

        public async Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken)
        {
            TResponse? result;
            using (var dbContextTransaction = _uow.BeginTransaction())
            {
                try
                {
                    //await _uow.ReadingLists.InsertAsync(new Domain.Aggregates.ReadingListRoot.ReadingList("hello", 1), cancellationToken);
                    //await _uow.SaveChangesAsync();

                    result = await _commandHandler.Handle(request, cancellationToken);
                    await _uow.SaveChangesAsync();
                    await _uow.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    await _uow.Rollback();
                    throw new DBException();
                }
                return default(TResponse);
            }
        }
    }
}
