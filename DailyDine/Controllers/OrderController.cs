using DailyDine.Core.Contracts;
using DailyDine.Infrastructure.Data.Entities;

using Microsoft.AspNetCore.Mvc;

namespace DailyDine.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMenuService menuService;

        public OrderController(IMenuService _menuService)
        {
            menuService = _menuService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Menu()
        {
            var today = DateTime.Now;
            var menu = menuService.GetMenuForDate(today);

            return View();
        }

        public async Task<IActionResult> Create()
        {
            var today = DateTime.Now;
            var menu = menuService.GetMenuForDate(today);

            return View();
        }
    }
}
