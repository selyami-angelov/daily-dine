using System.ComponentModel.DataAnnotations;

namespace DailyDine.Infrastructure.Data.Entities
{
    public class Category
    {
        [Key]
        public  int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = new List<Product>();

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}
