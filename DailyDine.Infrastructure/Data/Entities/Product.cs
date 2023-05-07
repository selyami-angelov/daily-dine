using Microsoft.EntityFrameworkCore.Metadata.Internal;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyDine.Infrastructure.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(150, MinimumLength = 40)]
        public string Description { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        [ForeignKey(nameof(CreatedBy))]
        public string CreatedById { get; set; } = null!;

        [Required]
        public DateTime EditedDate { get; set; }

        [Required]
        [ForeignKey(nameof(EditedBy))]
        public string EditedById { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public byte[] ProductImage { get; set; } = Array.Empty<byte>();


        public ICollection<Menu> Menus { get; set; } = new List<Menu>();
        public ICollection<LunchSubscription> LunchSubscriptions { get; set; } = new List<LunchSubscription>();
        public ApplicationUser CreatedBy { get; set; } = new ApplicationUser();
        public ApplicationUser EditedBy { get; set; } = new ApplicationUser();
        public Category Category { get; set; } = new Category();

    }
}
