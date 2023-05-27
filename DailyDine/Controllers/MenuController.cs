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

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var menuForToday = await menuService.GetMenuByDate(DateTime.Now);
            var menu = new MenuModel()
            {
                Categories = menuForToday.Products.Select(p => p.CategoryName).Distinct().ToList(),
                Date = menuForToday.Date,
                Products = menuForToday.Products
            };

            return View(menu);
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

            await menuService.CreateMenu(menu, selectedProductIds);

            return RedirectToAction(nameof(Create));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int menuId)
        {
            if (menuId == 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var menu = await menuService.GetMenuById(menuId);
            var products = await productService.GetAll();
            List<bool> selectedProducts = new List<bool>();

            foreach (var product in products)
            {
                if (menu.Products.FirstOrDefault(p => p.Id == product.Id) != null)
                {
                     selectedProducts.Add(true);
                }
                else
                {
                    selectedProducts.Add(false);
                }
            }

      

            var model = new CreateMenuModel()
            {
                Date = menu.Date,
                Products = products.ToList(),
                Selected = selectedProducts
            };


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateMenuModel model, int menuId)
        {

            if (menuId == 0)
            {
                return View(model);
            }

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
                EditedBy = user,
                EditedDate = DateTime.Now

            };

            await menuService.EditMenu(menuId, selectedProductIds);

            return RedirectToAction(nameof(Index));
        }
    }
}
