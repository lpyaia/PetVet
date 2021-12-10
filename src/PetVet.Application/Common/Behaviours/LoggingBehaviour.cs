using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using PetVet.Application.Common.Interfaces;
using PetVet.Application.Common.Security;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PetVet.Application.Common.Behaviours
{
    public class LoggingBehaviour<TRequest> :
        IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        private readonly ILogger<LoggingBehaviour<TRequest>> _logger;
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest>> logger,
            ICurrentUserService currentUserService,
            IIdentityService identityService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
            _identityService = identityService;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _currentUserService.UserId;
            string userName = string.Empty;

            if (userId != Guid.Empty)
            {
                userName = await _identityService.GetUserNameAsync(userId);
            }

            if (request.HasSecretContent())
            {
                return;
            }

            _logger.LogInformation("PetVet Request: {Name} {@UserId} {@UserName} {@Request}",
                requestName, userId, userName, request);
        }
    }
}