using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Responses;
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
            var result = await _commandHandler.Handle(request, cancellationToken);
            await _uow.SaveChangesAsync();
            return result;
        }
    }
}
