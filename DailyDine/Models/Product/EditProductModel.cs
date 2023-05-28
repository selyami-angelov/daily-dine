using System.ComponentModel.DataAnnotations;

namespace DailyDine.Models.Product
{
    public class EditProductModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(150, MinimumLength = 40)]
        public string Description { get; set; } = null!;

        [Required]
        public string CategoryName { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        public IFormFile? ProductImage { get; set; }
    }
}
