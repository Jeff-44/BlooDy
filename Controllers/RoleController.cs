using BlooDyWeb.Models.Security;
using BlooDyWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlooDyWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleController(
                RoleManager<IdentityRole> roleManager,
                UserManager<ApplicationUser> userManager
            )
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet("roles")]
        public IActionResult Index() => View(_roleManager.Roles);

        public async Task<IActionResult> DetailsRole(string id)
        {
            var users = _userManager.Users.ToList();
            List<ApplicationUser> members = new List<ApplicationUser>();
            List<ApplicationUser> nonMembers = new List<ApplicationUser>();

            try
            {
                var role = await _roleManager.FindByIdAsync(id);
                if(role == null) 
                {
                    return NotFound(id);
                }

                foreach (var user in users) 
                {
                    var list = _userManager.IsInRoleAsync(user, role.Name).GetAwaiter().GetResult() ? members : nonMembers;
                    list.Add(user);
                }

                return View(new RoleVM() 
                {
                    Role = role,
                    Members = members,
                    NonMembers = nonMembers
                });
            }
            catch (Exception ex) 
            { }
            return BadRequest(id);
        }


        public async Task<IActionResult> CreateRole() => View();

        [HttpPost]
        public async Task<IActionResult> CreateRole(IdentityRole model)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    if (!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
                    { 
                        var result = await _roleManager.CreateAsync(model);
                        if (result.Succeeded) 
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }

                }
            }
            catch (Exception ex) { }

            return BadRequest(model);
        }

        public async Task<IActionResult> UpdateRole(string id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role != null)
                {
                    return View(new RoleVM() { Role = role });
                }
            }
            catch (Exception ex) { }

            return BadRequest(id);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var role = await _roleManager.FindByIdAsync(model.Role.Id);
                    if (role != null)
                    {
                        role.Name = model.Role.Name;
                        role.NormalizedName = model?.Role?.Name?.ToUpper();
                        var result = await _roleManager.UpdateAsync(role);
                        if (result.Succeeded)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
            }
            catch (Exception ex) { }

            return BadRequest(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role != null)
                {
                    var result = await _roleManager.DeleteAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch (Exception ex) { }

            return BadRequest(id);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRoleToUsers(List<string> userIds, string roleName) 
        {
            try
            {
                if (_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult()) 
                {
                    var role = await _roleManager.FindByNameAsync(roleName);

                    foreach (var id in userIds)
                    {
                        var user = await _userManager.FindByIdAsync(id);
                        if (user != null) 
                        {
                            var result = await _userManager.AddToRoleAsync(user, roleName);
                        }
                    }
                    return RedirectToAction(nameof(DetailsRole), new { id = role.Id });
                }
            }
            catch (Exception ex) { }

            return BadRequest(roleName);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveUsersFromRole(List<string> userIds, string roleName) 
        {
            try
            {
                if (_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    var role = await _roleManager.FindByNameAsync(roleName);

                    foreach (var id in userIds)
                    {
                        var user = await _userManager.FindByIdAsync(id);
                        if (user != null)
                        {
                            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
                        }
                    }
                    return RedirectToAction(nameof(DetailsRole), new { id = role.Id });
                }
            }
            catch (Exception ex) { }

            return BadRequest(roleName);
        }
        
    }
}
