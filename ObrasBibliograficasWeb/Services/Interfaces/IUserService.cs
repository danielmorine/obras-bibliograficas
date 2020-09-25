using ObrasBibliograficasWeb.Models;
using ObrasBibliograficasWeb.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ObrasBibliograficasWeb.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserQuery>> GetAllAsync(BibliographiesModel model);
        Task AddRangeAsync();
    }
}
