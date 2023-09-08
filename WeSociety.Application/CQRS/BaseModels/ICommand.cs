using MediatR;

namespace WeSociety.Application.CQRS.BaseModels
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
