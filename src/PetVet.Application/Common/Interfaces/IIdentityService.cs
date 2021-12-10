using PetVet.Application.Common.Models;
using System;
using System.Threading.Tasks;

namespace PetVet.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(Guid userId);

        Task<bool> IsInRoleAsync(Guid userId, string role);

        Task<bool> AuthorizeAsync(Guid userId, string policyName);

        Task<(Result result, Guid UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(Guid userId);

        Task<Result> AddUserToRoleAsync(Guid userId, string role);
    }
}