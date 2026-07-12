using CleanArt.Application.Abstractions.Messaging.Command;
using CleanArt.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArt.Application.Abstractions.Behaviors
{
    public class LoggingBehaivor<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IBaseRequest
        where TResponse : Result
    {
        private readonly ILogger<LoggingBehaivor<TRequest,TResponse>> _logger;

        public LoggingBehaivor(ILogger<LoggingBehaivor<TRequest,TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var name= request.GetType().Name;

            try
            {
                _logger.LogInformation("Executing request {Request}", name);

                var result = await next();

                if (result.IsSuccess)
                {
                    _logger.LogInformation("Request {Request} processed successfuly", name);
                }
                else
                {
                    using (LogContext.PushProperty("Error", result.Error, true))
                    {
                        _logger.LogInformation("Command {Command} processed successfully", name);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Request {Request} processing failed", name);
                throw;
            }
        }
    }
}
