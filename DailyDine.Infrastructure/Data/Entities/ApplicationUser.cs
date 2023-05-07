using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;

namespace DailyDine.Infrastructure.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; } = null!;

        [Required]
        public bool IsAdmin { get; set; } = false;

    }
}
