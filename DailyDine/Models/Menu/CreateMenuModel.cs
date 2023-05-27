using DailyDine.Core.Dtos;
using DailyDine.Infrastructure.Data.Entities;

using System.ComponentModel.DataAnnotations;

namespace DailyDine.Models.Menu
{
    public class CreateMenuModel
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }


        [Required]
        public ApplicationUser CreatedBy { get; set; } = new ApplicationUser();

        [Required]
        public List<ProductDto> Products { get; set; }
        public List<bool> Selected { get; set; }

    }   
}
