using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NotMyFault.Constants;
using NotMyFault.Models.UserRelated;
using NotMyFault.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Start()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                if (user.Role == UserRole.Dev) return RedirectToAction("Index", "DevHome");
                if (user.Role == UserRole.Buyer) return RedirectToAction("Index", "BuyerHome");
            }
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);

            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginViewModel.ReturnUrl))
                    {
                        if (user.Role == UserRole.Dev) return RedirectToAction("Index", "DevHome");
                        if (user.Role == UserRole.Buyer) return RedirectToAction("Index", "BuyerHome");
                    }
                    return Redirect(loginViewModel.ReturnUrl);
                }
            }
            ModelState.AddModelError(string.Empty, "Username/password not found");
            return View(loginViewModel);
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                if (registerViewModel.Role == UserRole.Dev)
                {
                    var dev = new Developer()
                    {
                        UserName = registerViewModel.UserName,
                        Role = UserRole.Dev,
                        NickName = registerViewModel.NickName,
                        Email = registerViewModel.Email,
                        Country = registerViewModel.Country,
                        Region = registerViewModel.Region,
                        SelfIntro = registerViewModel.SelfIntro
                    };
                    var result = await _userManager.CreateAsync(dev, registerViewModel.Password);
                    return result.Succeeded ? RedirectToAction("Login", "Account") : RedirectToAction("Index", "ErrorPage");
                }
                else if (registerViewModel.Role == UserRole.Buyer)
                {
                    var buyer = new Buyer()
                    {
                        UserName = registerViewModel.UserName,
                        Role = UserRole.Buyer,
                        NickName = registerViewModel.NickName,
                        Email = registerViewModel.Email,
                        CompanyName = registerViewModel.CompanyName,
                        CompanyAddr = registerViewModel.CompanyAddr,
                        Country = registerViewModel.Country,
                        Region = registerViewModel.Region,
                    };
                    var result = await _userManager.CreateAsync(buyer, registerViewModel.Password);
                    return result.Succeeded ? RedirectToAction("Login", "Account") : RedirectToAction("Index", "ErrorPage");
                }
            }
            return View(registerViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Start", "Account");
        }
    }
}
