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

        public async Task Add(CategoryDto categoryDto)
        {
            var category = new Category()
            {
               Name = categoryDto.Name
            };

            await repo.AddAsync(category);
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

        public async Task<CategoryDto> GetById(int id)
        {
            var category = await repo.GetByIdAsync<Category>(id);

            if (category == null)
            {
                return null;
            }


            return new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
            };
        }

        public async Task<CategoryDto> GetByName(string name)
        {
            var category = await repo.All<Category>(c => c.Name == name).ToListAsync();

            if (!category.Any())
            {
                return null;
            }


            return new CategoryDto()
            {
                Id = category[0].Id,
                Name = category[0].Name,
            };
        }
    }
}
