using ButaAdminTask.Helpers;
using ButaAdminTask.Models;
using ButaAdminTask.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ButaAdminTask.Helpers.Helper;

namespace ButaAdminTask.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser>
            signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser appUser = await _userManager.FindByEmailAsync(loginVM.Email);
            if (appUser == null)
            {
                ModelState.AddModelError("Email", "İstifadəçi tapılmadı");
                return View();
            }
            Microsoft.AspNetCore.Identity.SignInResult signInResult=
            await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, true,true);
            if (!signInResult.Succeeded)

            {
                ModelState.AddModelError("", "Sizin şifrəniz yanlışdır");
                return View();
            }
           
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index","Dashboard");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser appUser = new AppUser
            {
                FullName = registerVM.FullName,
                UserName = registerVM.UserName,
                Email = registerVM.Email


            };

           IdentityResult identityResult=await _userManager.CreateAsync(appUser, registerVM.Password);
            if (!identityResult.Succeeded) 
            {
                foreach ( IdentityError error in identityResult.Errors)
                {
                    //Console.WriteLine(error.Description);
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            await _userManager.AddToRoleAsync(appUser, Roles.Member.ToString());
            await _signInManager.SignInAsync(appUser,true);
            return RedirectToAction("Index","Home");
        }


        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Register", "Account");
        }

        public async Task CreateRoles()
        {
            if (!await _roleManager.RoleExistsAsync(Roles.Admin.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = Roles.Admin.ToString() });
            }
            if (!await _roleManager.RoleExistsAsync(Roles.Member.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = Roles.Member.ToString() });
            }

        }


    }
}

