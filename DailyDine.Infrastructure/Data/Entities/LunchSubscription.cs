using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyDine.Infrastructure.Data.Entities
{
    public class LunchSubscription
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string SubscriptionId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice { get; set; }


        public ApplicationUser User { get; set; } = new ApplicationUser();

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
