using DailyDine.Core.Contracts;
using DailyDine.Core.Dtos;
using DailyDine.Models.Product;

using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

namespace DailyDine.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IUserService userService;


        public ProductController(IProductService _productService, ICategoryService _categoryService, IUserService _userService)
        {
            productService = _productService;
            categoryService = _categoryService;
            userService = _userService;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user =  await userService.GetUser(userId);


            var image = Array.Empty<byte>();
            using var stream = new MemoryStream();
            await model.ProductImage.CopyToAsync(stream);
            image = stream.ToArray();


            var product = new ProductDto()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ProductImage = image,
                CreatedBy = user,
                EditedBy = user,
                CategoryName = model.CategoryName
            };

            await productService.Add(product);
            return RedirectToAction("index", "home");

        }

    }
}
