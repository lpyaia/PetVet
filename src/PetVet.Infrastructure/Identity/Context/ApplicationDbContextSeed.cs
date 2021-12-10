using Microsoft.AspNetCore.Identity;
using PetVet.Domain.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetVet.Infrastructure.Identity.Context
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            await AddRoles(roleManager);
            await AddDefaultUsers(userManager);
        }

        private static async Task AddRoles(RoleManager<ApplicationRole> roleManager)
        {
            var roles = new List<ApplicationRole>
            {
                new ApplicationRole(Role.Administrator),
                new ApplicationRole(Role.Assistant),
                new ApplicationRole(Role.Customer),
                new ApplicationRole(Role.Vet)
            };

            foreach (var role in roles)
            {
                if (roleManager.Roles.Count(x => x.Name == role.Name) == 0)
                    await roleManager.CreateAsync(role);
            }
        }

        private static async Task AddDefaultUsers(UserManager<ApplicationUser> userManager)
        {
            var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };
            var vet = new ApplicationUser { UserName = "vet@localhost", Email = "vet@localhost" };
            var assistant = new ApplicationUser { UserName = "assistant@localhost", Email = "assistant@localhost" };
            var customer = new ApplicationUser { UserName = "customer@localhost", Email = "customer@localhost" };

            // all passwords were defined for test purposes only
            await AddUser(administrator, Role.Administrator, "Admin!123", userManager);
            await AddUser(vet, Role.Vet, "Vet!123", userManager);
            await AddUser(assistant, Role.Assistant, "Assistant!123", userManager);
            await AddUser(customer, Role.Customer, "Customer!123", userManager);
        }

        private static async Task AddUser(ApplicationUser user, string role, string password, UserManager<ApplicationUser> userManager)
        {
            if (userManager.Users.All(u => u.UserName != user.UserName))
            {
                await userManager.CreateAsync(user, password);
                await userManager.AddToRolesAsync(user, new[] { role });
            }
        }
    }
}