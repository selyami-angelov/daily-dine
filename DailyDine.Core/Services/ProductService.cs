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

        private readonly IRepository repository;

        /// <summary>
        /// IoC 
        /// </summary>
        /// <param name="_config">Application configuration</param>
        public ProductService(
            IRepository _repository)
        {
            repository = _repository;
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

            var category = await repository.All<Category>(c => c.Name == productDto.CategoryName).FirstOrDefaultAsync();

            if (category == null)
            {
                category = new Category()
                {
                    Name = productDto.CategoryName
                };
                await repository.AddAsync(category);
            }

            category.Products.Add(product);
            await repository.SaveChangesAsync();
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
        public async Task<ICollection<ProductDto>> GetAll()
        {
            return await repository.AllReadonly<Product>()
                .Select(p => new ProductDto()
                {
                    CategoryName=p.Category.Name,
                    Description=p.Description,
                    Price = p.Price,
                    Name = p.Name,
                    ProductImage=p.ProductImage,
                    Id = p.Id
                }).ToListAsync();
        }

    }
}
