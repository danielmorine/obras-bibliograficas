using Microsoft.EntityFrameworkCore;
using ObrasBibliograficasWeb.Db.Interfaces;
using ObrasBibliograficasWeb.Schemas;

namespace ObrasBibliograficasWeb.Db
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
        }
        public string ConnectionString { get; set; }
        public DbSet<User> User { get; set; }
    }
}
