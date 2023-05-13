using DailyDine.Infrastructure.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyDine.Core.Dtos
{
    /// <summary>
    /// Product model
    /// </summary>
    public class ProductDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [StringLength(150, MinimumLength = 40)]
        public string Description { get; set; } = null!;

        public DateTime CreatedDate { get; set; }


        public DateTime EditedDate { get; set; }


        public decimal Price { get; set; }

        public string CategoryName { get; set; } = null!;

        public byte[] ProductImage { get; set; } = Array.Empty<byte>();

        public ApplicationUser CreatedBy { get; set; }

        public ApplicationUser EditedBy { get; set; }
    }
}
