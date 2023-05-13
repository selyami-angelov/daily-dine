using DailyDine.Core.Dtos;
using DailyDine.Infrastructure.Data.Entities;

namespace DailyDine.Core.Contracts
{
    public interface ICategoryService
    {

        Task<IEnumerable<CategoryDto>> GetAll();


        Task AddProduct(ProductDto product);

        Task Delete(int id);
    }
}
