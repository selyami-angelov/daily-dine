using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyDine.Infrastructure.Data.Entities
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string OrderId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice { get; set; }


        public ApplicationUser User { get; set; } = new ApplicationUser();

        public ICollection<Product> Products { get; set; } = new List<Product>();

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}
