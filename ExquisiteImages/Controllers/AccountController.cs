using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExquisiteImages.Models;
using Microsoft.AspNetCore.Identity;

namespace ExquisiteImages.Controllers
{
    public class AccountController : Controller
    {
        UserManager<AppUser> userManager;
        SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> ustManager, SignInManager<AppUser> signManager)
        {
            userManager = ustManager;
            signInManager = signManager;
        }

        public ViewResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                await signInManager.SignOutAsync();
                AppUser user = await userManager.FindByEmailAsync(model.Email);
                if(user != null)
                {
                     Microsoft.AspNetCore.Identity.SignInResult result= await 
                                    signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (result.Succeeded)
                        return Redirect(returnUrl ?? "/");
                }
                ModelState.AddModelError("","Invalid user or Password");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
