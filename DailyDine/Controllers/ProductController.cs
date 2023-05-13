using DailyDine.Core;
using DailyDine.Core.Contracts;
using DailyDine.Core.Dtos;
using DailyDine.Core.Models;
using DailyDine.Infrastructure.Data.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

using static DailyDine.Core.Constants;

namespace DailyDine.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService _productService, ICategoryService _categoryService)
        {
            productService = _productService;
            categoryService = _categoryService;

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
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}

            var category = await categoryService.GetByName(model.CategoryName);


            if (category == null)
            {
                var newCategory = new CategoryDto()
                {
                    Name = model.CategoryName,
                };

                await categoryService.Add(newCategory);
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var image = Array.Empty<byte>();
            using var stream = new MemoryStream();
            await model.ProductImage.CopyToAsync(stream);
            image = stream.ToArray();


            var product = new ProductDto()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                CategoryId = category.Id,
                CreatedById = userId,
                EditedById = userId,
                CreatedDate = new DateTime(),
                EditedDate = new DateTime(),
                ProductImage = image
            };

            await productService.Add(product);

            return View();

        }

    }
}
