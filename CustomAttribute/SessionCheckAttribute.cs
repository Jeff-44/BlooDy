using BlooDyWeb.Models.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlooDyWeb.CustomAttribute
{
    public class SessionCheckAttribute : ActionFilterAttribute
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        public SessionCheckAttribute(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            
        }
        public async override void OnActionExecuting(ActionExecutingContext context)
        {
            var userSession = context.HttpContext.Session;
            if (string.IsNullOrEmpty(userSession.GetString("Username")) && context.HttpContext.User.Identity.IsAuthenticated) 
            {
                await _signInManager.SignOutAsync();
                context.Result = new RedirectResult("/Identity/Account/Login");
            }
            base.OnActionExecuting(context);
        }
    }
}
