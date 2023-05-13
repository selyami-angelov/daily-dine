using DailyDine.Core.Contracts;
using DailyDine.Core.Dtos;
using DailyDine.Infrastructure.Data.Entities;

using Microsoft.EntityFrameworkCore;

namespace DailyDine.Core.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly IRepository repo;

        public CategoryService(
            IRepository _repo)
        {
            repo = _repo;
        }

        public async Task AddProduct(ProductDto productDto)
        {
           var category =  await repo.All<Category>(c => c.Name == productDto.CategoryName).FirstOrDefaultAsync();

            if(category == null)
            {
                category = new Category()
                {
                    Name = productDto.CategoryName
                };
                await repo.AddAsync(category);
            }

            var product = new Product()
            {
                Name = productDto.Name,
                CreatedBy = productDto.CreatedBy,
                CreatedById = productDto.CreatedBy.Id,
                EditedBy = productDto.EditedBy,
                EditedById = productDto.EditedBy.Id,
                CreatedDate = DateTime.Now ,
                EditedDate = DateTime.Now,
                Description = productDto.Description,
                Price = productDto.Price,
                ProductImage = productDto.ProductImage
            };


            category.Products.Add(product);
            await repo.SaveChangesAsync();

        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
