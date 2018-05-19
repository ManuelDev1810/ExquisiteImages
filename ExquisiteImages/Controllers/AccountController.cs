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

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginModel model, string returnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {

        //    }
        //}
    }
}
