using System.Threading;
using System.Threading.Tasks;

namespace PetVet.Application.Common.Interfaces
{
    public interface IBaseAppDbContext
    {
        // DbSet<Category> Categories { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
