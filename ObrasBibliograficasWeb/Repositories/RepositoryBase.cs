using Microsoft.EntityFrameworkCore;
using ObrasBibliograficasWeb.Db.Interfaces;
using ObrasBibliograficasWeb.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ObrasBibliograficasWeb.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly IApplicationDbContext _db;

        private bool disposed = false;

        public RepositoryBase(IApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<T>> GetAllAsnc(Expression<Func<T, bool>> condiction, bool asNoTracking = false, int take = 10, int skip = 1)
        {
            var query = _db.Set<T>().AsQueryable();
            if (asNoTracking)
            {
                query = _db.Set<T>().AsNoTracking().AsQueryable();
            }
            skip = take * (skip - 1);
            if (condiction == null)
            {
                return await query.Skip(skip).Take(take).ToListAsync();
            }

            return await query.Where(condiction).Skip(skip).Take(take).ToListAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (_db != null)
                    {
                        _db.Dispose();
                    }
                }
            }
            disposed = true;
        }

        public async Task AddRangeAsync(IEnumerable<T> schemas)
        {
            await _db.Set<T>().AddRangeAsync(schemas);
        }

        public async Task SaveChangeAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
