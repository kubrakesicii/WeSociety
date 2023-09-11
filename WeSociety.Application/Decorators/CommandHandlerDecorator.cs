using Nest;
using WeSociety.Application.CQRS.BaseModels;
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
            TResponse result;
            await _uow.BeginTransaction();
            try
            {
                result = await _commandHandler.Handle(request, cancellationToken);
                await _uow.ReadingLists.InsertAsync(new Domain.Aggregates.ReadingListRoot.ReadingList("xx", 465465),cancellationToken);
                await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await _uow.Rollback();

            }
            await _uow.Commit();
            return await _commandHandler.Handle(request, cancellationToken);
        }
    }
}
