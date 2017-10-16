using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NotMyFault.Models.UserRelated;
using NotMyFault.ViewModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NotMyFault.Components
{
    public class Header : ViewComponent
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public Header(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                return View(user);
            }
            else
            {
                return View();
            }
        }
    }
}
