using DailyDine.Core.Contracts;
using DailyDine.Core.Dtos;
using DailyDine.Core.Models;
using DailyDine.Infrastructure.Data;

using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

namespace DailyDine.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ApplicationDbContext dbContext;


        public ProductController(IProductService _productService, ICategoryService _categoryService, ApplicationDbContext _dbContext)
        {
            productService = _productService;
            categoryService = _categoryService;
            dbContext = _dbContext;

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

        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = dbContext.Users.FirstOrDefault(u => u.Id == userId);


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

            await categoryService.AddProduct(product);
            return RedirectToAction("index", "home");

        }

    }
}
