using ExquisiteImages.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

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
        public async Task<IActionResult> Register(CreateUser model, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if(img != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/profile/", img.FileName);
                    using(var stram = new FileStream(path, FileMode.Create))
                    {
                        await img.CopyToAsync(stram);
                    }

                    AppUser user = new AppUser
                    {
                        UserName = model.Name,
                        Email = model.Email,
                        ProfilePicture = "/img/profile/" + img.FileName
                    };

                    IdentityResult result = await userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                        return RedirectToAction("Login", "Account");
                    else
                        AddErrorsFromIdentityResult(result);
                }
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
