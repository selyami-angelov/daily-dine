using DailyDine.Infrastructure.Data.Entities;

namespace DailyDine.Core.Dtos
{
    public class MenuDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime EditedDate { get; set; }

        public ApplicationUser CreatedBy { get; set; } = new ApplicationUser();

        public ApplicationUser EditedBy { get; set; } = new ApplicationUser();

        public ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
