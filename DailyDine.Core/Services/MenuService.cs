using DailyDine.Core.Contracts;
using DailyDine.Core.Dtos;
using DailyDine.Infrastructure.Data.Entities;

using Microsoft.EntityFrameworkCore;

namespace DailyDine.Core.Services
{
    public class MenuService : IMenuService
    {
        private readonly IRepository repository;

        public MenuService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<MenuDto> GetMenuByDate(DateTime date)
        {

            var menu = await repository.FirstOrDefaultAsync<Menu, ICollection<Product>>(m => m.Date.Year == date.Year && m.Date.Month == date.Month && m.Date.Day == date.Day, m => m.Products);
            return new MenuDto()
            {
                Id = menu.Id,
                CreatedBy = menu.CreatedBy,
                CreatedDate = menu.CreatedDate,
                EditedBy = menu.EditedBy,
                EditedDate = menu.EditedDate,
                Products = menu.Products.Select(p => new ProductDto()
                {
                    Id = p.Id,
                    CategoryName = p.Category.Name,
                    Description = p.Description,
                    Name = p.Name,
                    Price = p.Price,
                    ProductImage = p.ProductImage
                }).ToList(),
                Date = menu.Date,
            };
        }

        public async Task<MenuDto> GetMenuById(int menuId)
        {
            var menu = await repository.FirstOrDefaultAsync<Menu, ICollection<Product>>(m => m.Id == menuId, m => m.Products);
            return new MenuDto()
            {
                CreatedBy = menu.CreatedBy,
                CreatedDate = menu.CreatedDate,
                EditedBy = menu.EditedBy,
                EditedDate = menu.EditedDate,
                Products = menu.Products
                .Where(p => !p.IsDeleted)
                .Select(p => new ProductDto()
                {
                    Id = p.Id,
                    CategoryName = p.Category.Name,
                    Description = p.Description,
                    Name = p.Name,
                    Price = p.Price,
                    ProductImage = p.ProductImage
                }).ToList(),
                Date = menu.Date,
            };
        }

        public async Task CreateMenu(MenuDto menuDto, List<int> productIds)
        {
            var products = await repository.All<Product>(product => productIds.Contains(product.Id))
                .Where(p => !p.IsDeleted)
                .ToListAsync();
            var menu = new Menu()
            {
                Id = menuDto.Id,
                Date = menuDto.Date,
                CreatedBy = menuDto.CreatedBy,
                CreatedDate = menuDto.CreatedDate,
                EditedBy = menuDto.EditedBy,
                EditedById = menuDto.CreatedBy.Id,
                EditedDate = menuDto.CreatedDate,
                Products = products
            };

            await repository.AddAsync(menu);
            await repository.SaveChangesAsync();
        }

        public async Task EditMenu(int menuId, List<int> productIds)
        {
            var menu = await repository.FirstOrDefaultAsync<Menu, ICollection<Product>>(m => m.Id == menuId, m => m.Products);
            var products = await repository
                .All<Product>(product => productIds.Contains(product.Id))
                .Where(p => !p.IsDeleted)
                .ToListAsync();

            menu.Products.Clear();
            menu.Products = products;
            await repository.SaveChangesAsync();
        }
    }
}
