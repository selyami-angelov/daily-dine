using DailyDine.Core.Contracts;
using DailyDine.Core.Dtos;
using DailyDine.Core.Services;
using DailyDine.Models.Menu;

using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

namespace DailyDine.Controllers
{
    public class MenuController : Controller
    {
        private readonly IProductService productService;
        private readonly IMenuService menuService;
        private readonly IUserService userService;

        public MenuController(IProductService _productService, IMenuService _menuService, IUserService _userService)
        {
            productService = _productService;
            menuService = _menuService;
            userService = _userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var products = await productService.GetAll();

            var model = new CreateMenuModel();

            if (products != null)
            {
                model.Products = products.ToList();
                model.Selected = new List<bool>(new bool[model.Products.Count]);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMenuModel model)
        {
            DateTime selectedDateTime = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day, 12, 00, 0);
            List<int> selectedProductIds = new List<int>();

            for (int i = 0; i < model.Products.Count; i++)
            {
                if (model.Selected[i])
                {
                    selectedProductIds.Add(model.Products[i].Id);
                }
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userService.GetUser(userId);
            var menu = new MenuDto()
            {
                CreatedBy = user,
                CreatedDate = DateTime.Now,
                Date = selectedDateTime,
                EditedBy = user,
                EditedDate = DateTime.Now

            };

            await menuService.CreateMenuForDate(menu, selectedProductIds);

            return RedirectToAction(nameof(Create));
        }
    }
}
