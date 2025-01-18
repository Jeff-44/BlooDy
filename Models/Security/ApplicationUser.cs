using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlooDyWeb.Models.Security
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string Firstname { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Lastname { get; set; } = string.Empty;

    }
}
