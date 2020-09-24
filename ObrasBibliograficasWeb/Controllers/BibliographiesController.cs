using Microsoft.AspNetCore.Mvc;
using ObrasBibliograficasWeb.Models;
using ObrasBibliograficasWeb.Services.Interfaces;
using System.Threading.Tasks;

namespace ObrasBibliograficasWeb.Controllers
{
    public class BibliographiesController : Controller
    {
        private readonly IUserService _userService;

        public BibliographiesController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(BibliographiesModel model)
        {
            await _userService.GetAllAsync(model);
            return View();
        }
    }
}