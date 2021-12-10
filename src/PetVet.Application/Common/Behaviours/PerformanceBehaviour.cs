using MediatR;
using Microsoft.Extensions.Logging;
using PetVet.Application.Common.Interfaces;
using PetVet.Application.Common.Security;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace PetVet.Application.Common.Behaviours
{
    public class PerformanceBehaviour<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;

        public PerformanceBehaviour(ILogger<TRequest> logger,
            ICurrentUserService currentUserService,
            IIdentityService identityService)
        {
            _timer = new Stopwatch();
            _logger = logger;
            _currentUserService = currentUserService;
            _identityService = identityService;
        }

        public async Task<TResponse> Handle(TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;

            if (elapsedMilliseconds > 500)
            {
                var requestName = typeof(TRequest).Name;
                var userId = _currentUserService?.UserId ?? Guid.Empty;
                var userName = string.Empty;

                if (userId != Guid.Empty)
                {
                    userName = await _identityService.GetUserNameAsync(userId);
                }

                if (!request.HasSecretContent())
                {
                    _logger.LogWarning("PetVet Long Running Request: {Name} " +
                        "({ElapsedMilliseconds} milliseconds) {@UserId} {@UserName} {@Request}",
                        requestName, elapsedMilliseconds, userId, userName, request);
                }
            }

            return response;
        }
    }
}