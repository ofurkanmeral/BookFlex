using CleanArt.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArt.Application.Abstractions.Messaging.Query
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {

    }
}
