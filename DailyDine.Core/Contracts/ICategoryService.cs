using DailyDine.Core.Dtos;

namespace DailyDine.Core.Contracts
{
    public interface ICategoryService
    {
        Task<CategoryDto> GetById(int id);

        Task<CategoryDto> GetByName(string name);
        Task<IEnumerable<CategoryDto>> GetAll();

        Task Add(CategoryDto categoryDto);

        Task Delete(int id);
    }
}
