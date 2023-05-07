using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyDine.Infrastructure.Data.Entities
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

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


        public ApplicationUser CreatedBy { get; set; } = new ApplicationUser();

        public ApplicationUser EditedBy { get; set; } = new ApplicationUser();
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
