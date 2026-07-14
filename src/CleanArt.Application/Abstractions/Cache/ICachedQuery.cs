using CleanArt.Application.Abstractions.Messaging.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArt.Application.Abstractions.Cache
{
    public interface ICachedQuery<TResponse> : IQuery<TResponse>,ICachedQuery;
    
    public interface ICachedQuery
    {
        string CacheKey { get; }
        TimeSpan? Expiration { get; }
    }
    
}
