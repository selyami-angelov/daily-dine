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
