using MediatR;
using Microsoft.Extensions.Logging;
using PetVet.Application.Common.Security;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetVet.Application.Common.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly ILogger<UnhandledExceptionBehaviour<TRequest, TResponse>> _logger;

        public UnhandledExceptionBehaviour(ILogger<UnhandledExceptionBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }

            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;

                if (request.HasSecretContent())
                {
                    _logger.LogError(ex, "PetVet Request: Unhandled Exception for Request {Name}",
                        requestName);
                }

                else
                {
                    _logger.LogError(ex, "PetVet Request: Unhandled Exception for Request {Name} {@Request}",
                        requestName, request);
                }

                throw;
            }
        }
    }
}