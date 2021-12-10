using PetVet.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System;
using PetVet.Domain.Common;

namespace PetVet.Web.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Guid UserId => GetUserId();

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetUserId()
        {
            var userId = _httpContextAccessor
                            .HttpContext?
                            .User?
                            .FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId.IsNotNullAndNotEmpty())
                return new Guid(userId);

            return Guid.Empty;
        }
    }
}