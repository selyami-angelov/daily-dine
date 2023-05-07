using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyDine.Infrastructure.Data.Entities
{
    public class MenuSaved
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Menu))]
        public int MenuId { get; set; } 

        public Menu Menu { get; set; } = new Menu();
    }
}


















