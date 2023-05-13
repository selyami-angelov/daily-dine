using DailyDine.Core.Contracts;
using DailyDine.Core.Dtos;
using DailyDine.Infrastructure.Data.Entities;

using Microsoft.EntityFrameworkCore;

namespace DailyDine.Core.Services
{
    /// <summary>
    /// Manipulates product data
    /// </summary>
    public class ProductService : IProductService
    {

        private readonly IRepository repo;

        /// <summary>
        /// IoC 
        /// </summary>
        /// <param name="_config">Application configuration</param>
        public ProductService(
            IRepository _repo)
        {
            repo = _repo;
        }

        public async Task Add(ProductDto productDto)
        {
            var product = new Product()
            {
                Name = productDto.Name,
                CreatedBy = productDto.CreatedBy,
                CreatedById = productDto.CreatedBy.Id,
                EditedBy = productDto.EditedBy,
                EditedById = productDto.EditedBy.Id,
                CreatedDate = DateTime.Now,
                EditedDate = DateTime.Now,
                Description = productDto.Description,
                Price = productDto.Price,
                ProductImage = productDto.ProductImage
            };

            var category = await repo.All<Category>(c => c.Name == productDto.CategoryName).FirstOrDefaultAsync();

            if (category == null)
            {
                category = new Category()
                {
                    Name = productDto.CategoryName
                };
                await repo.AddAsync(category);
            }

            category.Products.Add(product);
            await repo.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            //var product = await repo.All<Product>()
            //    .FirstOrDefaultAsync(p => p.Id == id);

            //if (product != null)
            //{
            //    product.IsActive = false;

            //    await repo.SaveChangesAsync();
            //}
        }

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>List of products</returns>
        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            //return await repo.AllReadonly<Product>()
            //    .Where(p => p.IsActive)
            //    .Select(p => new ProductDto()
            //    {
            //        Id = p.Id,
            //        Name = p.Name,
            //        Price = p.Price,
            //        Quantity = p.Quantity
            //    }).ToListAsync();

            return Array.Empty<ProductDto>();
        }
    }
}
