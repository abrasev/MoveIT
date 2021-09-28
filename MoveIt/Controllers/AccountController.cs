using BuisnessLayer.ViewModels;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoveIt.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<MoverUser> _userManager;
        private readonly SignInManager<MoverUser> _signInManager;
        private readonly RoleManager<MoverRole> _roleManager;

        public AccountController(UserManager<MoverUser> userManager, RoleManager<MoverRole> roleManager, SignInManager<MoverUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Register(RegisterViewModel moverUser)
        {
            if (ModelState.IsValid)
            {
                var user = new MoverUser {FirstName = moverUser.FirstName, LastName = moverUser.LastName, UserName = moverUser.UserName, Email = moverUser.Email };
                var result = await _userManager.CreateAsync(user, moverUser.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(moverUser);
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel moverUser)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(moverUser.UserName, moverUser.Password, false, false);
            if (signInResult.Succeeded)
            {
                return RedirectToAction("Index", "MoveProposal");
            }
            return View(moverUser);
        }        
        public new async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
