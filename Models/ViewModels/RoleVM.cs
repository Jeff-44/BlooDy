using BlooDyWeb.Models.Security;
using Microsoft.AspNetCore.Identity;

namespace BlooDyWeb.Models.ViewModels
{
    public class RoleVM
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<ApplicationUser> Members { get; set;} = Enumerable.Empty<ApplicationUser>();
        public IEnumerable<ApplicationUser> NonMembers { get; set;} = Enumerable.Empty<ApplicationUser>();

    }
}
