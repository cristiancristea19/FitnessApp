using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDbContext
    {
        DbSet<T> Set<T>() where T : class;

        Task SaveChangesAsync(CancellationToken cancellationToken);

        void SaveChanges();
    }
}