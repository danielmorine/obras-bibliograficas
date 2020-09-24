using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ObrasBibliograficasWeb.Repositories.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task AddRangeAsync(IEnumerable<T> schemas);
        Task SaveChangeAsync();
        Task<IEnumerable<T>> GetAllAsnc(Expression<Func<T, bool>> condiction, bool asNoTracking = false, int take = 10, int skip = 1);
    }
}
