using ExquisiteImages.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExquisiteImages.Controllers
{
    public class AdminController : Controller
    {
        UserManager<AppUser> userManager;

        public AdminController(UserManager<AppUser> usMr)
        {
            userManager = usMr;
        }

        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateUser model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                   UserName = model.Name,
                   Email = model.Email
                };

                IdentityResult result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
                else
                    AddErrorsFromIdentityResult(result);
            }
            return View("Login", "Account");
        }

        private void AddErrorsFromIdentityResult(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}
