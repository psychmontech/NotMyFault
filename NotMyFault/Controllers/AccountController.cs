﻿using Microsoft.AspNetCore.Authorization;
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

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager)
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
        public IActionResult DevRegister()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> DevRegister(DevRegisterViewModel devRegisterViewModel)
        {
            if (ModelState.IsValid)
            {
                var dev = new Developer()
                {
                    UserName = devRegisterViewModel.UserName,
                    Role = UserRole.Dev,
                    NickName = devRegisterViewModel.NickName,
                    Email = devRegisterViewModel.Email,
                    Country = devRegisterViewModel.Country,
                    Region = devRegisterViewModel.Region,
                    SelfIntro = devRegisterViewModel.SelfIntro 
                };
                var result = await _userManager.CreateAsync(dev, devRegisterViewModel.Password);
                return result.Succeeded? RedirectToAction("Login", "Account") : RedirectToAction("Index", "ErrorPage");
            }
            return View(devRegisterViewModel);
        }

        [AllowAnonymous]
        public IActionResult BuyerRegister()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> BuyerRegister(BuyerRegisterViewModel buyerRegisterViewModel)
        {
            if (ModelState.IsValid)
            {
                var dev = new Buyer()
                {
                    UserName = buyerRegisterViewModel.UserName,
                    Role = UserRole.Buyer,
                    NickName = buyerRegisterViewModel.NickName,
                    Email = buyerRegisterViewModel.Email,
                    CompanyName = buyerRegisterViewModel.CompanyName,
                    CompanyAddr = buyerRegisterViewModel.CompanyAddr,
                    Country = buyerRegisterViewModel.Country,
                    Region = buyerRegisterViewModel.Region,
                };
                var result = await _userManager.CreateAsync(dev, buyerRegisterViewModel.Password);
                return result.Succeeded ? RedirectToAction("Login", "Account") : RedirectToAction("Index", "ErrorPage");
            }
            return View(buyerRegisterViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Start", "Account");
        }
    }
}
