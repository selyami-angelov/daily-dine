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

        public async Task Delete(int id)
        {
            var product = await repository.FirstOrDefaultAsync<Product>(p => p.Id == id);

            if (product != null)
            {
                product.IsDeleted = true;
                await repository.SaveChangesAsync();
            }
        }

        public async Task Edit(ProductDto productDto, int productId)
        {
            var category = await repository.FirstOrDefaultAsync<Category>(c => c.Name == productDto.CategoryName);

            if (category == null)
            {
                category = new Category()
                {
                    Name = productDto.CategoryName
                };
                await repository.AddAsync<Category>(category);
            }

            var product = await repository.GetByIdAsync<Product>(productId);
            product.Category = category;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.EditedBy = productDto.EditedBy;
            product.EditedDate = productDto.EditedDate;
            product.Name = productDto.Name;

            if (productDto.ProductImage.Length != 0)
            {
                product.ProductImage = productDto.ProductImage;
            }

            await repository.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>List of products</returns>
        public async Task<ICollection<ProductDto>> GetAll()
        {
            return await repository.AllReadonly<Product>()
                .Where(p => !p.IsDeleted)
                .Select(p => new ProductDto()
                {
                    CategoryName = p.Category.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Name = p.Name,
                    ProductImage = p.ProductImage,
                    Id = p.Id
                }).ToListAsync();
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product = await repository.GetByIdAsync<Product>(id);

            return new ProductDto()
            {
                CategoryName = product.Category.Name,
                Description = product.Description,
                Price = product.Price,
                Name = product.Name,
                ProductImage = product.ProductImage,
                Id = product.Id,
                CreatedBy = product.CreatedBy,
                CreatedDate = product.CreatedDate,
                EditedBy = product.EditedBy,
                EditedDate = product.EditedDate
            };
        }

        public async Task<ProductDto> GetByIdIncludingCategory(int id)
        {
            var product = await repository.FirstOrDefaultAsync<Product, Category>(product => product.Id == id, product => product.Category);

            return new ProductDto()
            {
                CategoryName = product.Category.Name,
                Description = product.Description,
                Price = product.Price,
                Name = product.Name,
                ProductImage = product.ProductImage,
                Id = product.Id,
                CreatedBy = product.CreatedBy,
                CreatedDate = product.CreatedDate,
                EditedBy = product.EditedBy,
                EditedDate = product.EditedDate
            };
        }
    }
}
