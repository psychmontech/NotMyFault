﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<ProjectController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
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
            if (ModelState.IsValid)
            {
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
            }

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

        public async Task<IActionResult> EditUserProfile()
        {
            User user = await _userManager.GetUserAsync(User);
            EditUserProfileViewModel editUserProfileViewModel = null;
            if (user.Role == UserRole.Dev)
            {
                Developer dev = (Developer) user;
                editUserProfileViewModel = new EditUserProfileViewModel
                {
                    Role = dev.Role,
                    NickName = dev.NickName,
                    Email = dev.Email,
                    Country = dev.Country,
                    Region = dev.Region,
                    SelfIntro = dev.SelfIntro
                };
                return View(editUserProfileViewModel);
            }

            else if (user.Role == UserRole.Buyer)
            {
                Buyer buyer = (Buyer)user;
                editUserProfileViewModel = new EditUserProfileViewModel
                {
                    Role = buyer.Role,
                    NickName = buyer.NickName,
                    Email = buyer.Email,
                    Country = buyer.Country,
                    Region = buyer.Region,
                    CompanyName = buyer.CompanyName,
                    CompanyAddr = buyer.CompanyAddr
                };
            }

            return View(editUserProfileViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserProfile(EditUserProfileViewModel editUserProfileViewModel)
        {
            User user = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                if (user.Role == UserRole.Dev)
                {
                    Developer dev = (Developer)user;
                    dev.NickName = editUserProfileViewModel.NickName;
                    dev.Email = editUserProfileViewModel.Email;
                    dev.Country = editUserProfileViewModel.Country;
                    dev.Region = editUserProfileViewModel.Region;
                    dev.SelfIntro = editUserProfileViewModel.SelfIntro;

                    var result = await _userManager.UpdateAsync(dev);
                    return result.Succeeded ? RedirectToAction("Index", "DevHome") : RedirectToAction("Index", "ErrorPage");
                }
                else if (user.Role == UserRole.Buyer)
                {
                    Buyer buyer = (Buyer)user;
                    buyer.NickName = editUserProfileViewModel.NickName;
                    buyer.Email = editUserProfileViewModel.Email;
                    buyer.Country = editUserProfileViewModel.Country;
                    buyer.Region = editUserProfileViewModel.Region;
                    buyer.CompanyName = editUserProfileViewModel.CompanyName;
                    buyer.CompanyAddr = editUserProfileViewModel.CompanyAddr;

                    var result = await _userManager.UpdateAsync(buyer);
                    return result.Succeeded ? RedirectToAction("Index", "BuyerHome") : RedirectToAction("Index", "ErrorPage");
                }
            }

            return View(editUserProfileViewModel);
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.GetUserAsync(User);
                var oldPwChkResult = await _signInManager.PasswordSignInAsync(user, changePasswordViewModel.OldPassword, false, false);

                if (oldPwChkResult.Succeeded)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, changePasswordViewModel.NewPassword);
                    var result = await _userManager.UpdateAsync(user);
                    return result.Succeeded ? RedirectToAction("EditUserProfile", "Account") : RedirectToAction("Index", "ErrorPage");
                }
                else ModelState.AddModelError(string.Empty, "incorrect password");
            }

            return View(changePasswordViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Start", "Account");
        }
    }
}
