using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ObrasBibliograficasWeb.Schemas;
using System.Threading;
using System.Threading.Tasks;

namespace ObrasBibliograficasWeb.Db.Interfaces
{
    public interface IApplicationDbContext
    {
        string ConnectionString { get; set; }
        DbSet<User> User { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        EntityEntry Entry(object entity);
        DbSet<T> Set<T>() where T : class;
        void Dispose();

    }
}
