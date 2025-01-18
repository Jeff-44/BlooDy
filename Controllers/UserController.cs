using BlooDyWeb.Models.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlooDyWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("users")]
        public IActionResult Index()
        {
            IEnumerable<ApplicationUser> users = Enumerable.Empty<ApplicationUser>();
            users = _userManager.Users.ToList();
            return View(users);
        }

        public async Task<IActionResult> UserDetails(string id)
        {
            ApplicationUser? user = new();
            try
            {
                user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound(id);
                }
            }
            catch (Exception ex)
            { }

            return View(user);
        }

        public async Task<IActionResult> EditUser(string id)
        {
            ApplicationUser? user = new();
            try
            {
                user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return BadRequest(id);
                }
            }
            catch (Exception ex)
            { }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(ApplicationUser model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if (user == null)
                {
                    return BadRequest(model);
                }

                user.Email = model.Email;
                user.UserName = model.UserName;
                user.Firstname = model.Firstname;
                user.Lastname = model.Lastname;
                user.PhoneNumber = model.PhoneNumber;
                user.NormalizedEmail = model.Email?.ToUpper();
                user.NormalizedUserName = model.UserName?.ToUpper();

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(UserDetails), new { id = user.Id });
                }
            }
            catch (Exception ex)
            { }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    var result = await _userManager.DeleteAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch (Exception ex)
            { }

            return BadRequest(id);
        }
        public IActionResult Privacy() => View();
    }
}
