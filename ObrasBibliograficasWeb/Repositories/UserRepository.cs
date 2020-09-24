using ObrasBibliograficasWeb.Db.Interfaces;
using ObrasBibliograficasWeb.Repositories.Interfaces;
using ObrasBibliograficasWeb.Schemas;

namespace ObrasBibliograficasWeb.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IApplicationDbContext db) : base(db) {}        
    }
}
