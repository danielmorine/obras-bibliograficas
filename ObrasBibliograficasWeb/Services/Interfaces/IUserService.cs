using ObrasBibliograficasWeb.Models;
using System.Threading.Tasks;

namespace ObrasBibliograficasWeb.Services.Interfaces
{
    public interface IUserService
    {
        Task GetAllAsync(BibliographiesModel model);
        Task PostAsync();
    }
}
