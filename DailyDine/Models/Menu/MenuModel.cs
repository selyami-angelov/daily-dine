using DailyDine.Core.Dtos;

namespace DailyDine.Models.Menu
{
    public class MenuModel
    {
        public DateTime Date { get; set; }
        public ICollection<string> Categories { get; set; } = null!;
        public ICollection<ProductDto> Products { get; set; } = null!;
    }
}
