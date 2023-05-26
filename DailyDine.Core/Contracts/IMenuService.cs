using DailyDine.Core.Dtos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyDine.Core.Contracts
{
    public interface IMenuService
    {
        Task<MenuDto> GetMenuForDate(DateTime date);

        Task<MenuDto> GetMenuById(int menuId);

        Task CreateMenuForDate(MenuDto menuDto, List<int> productIds);
    }
}
