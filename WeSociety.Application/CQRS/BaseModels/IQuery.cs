using MediatR;

namespace WeSociety.Application.CQRS.BaseModels
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
