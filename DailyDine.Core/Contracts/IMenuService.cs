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
        Task<MenuDto> GetMenuByDate(DateTime date);

        Task<MenuDto> GetMenuById(int menuId);

        Task CreateMenu(MenuDto menuDto, List<int> productIds);
        Task EditMenu(int menuId, List<int> productIds);
    }
}
