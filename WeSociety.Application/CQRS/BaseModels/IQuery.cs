using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.BaseModels
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
