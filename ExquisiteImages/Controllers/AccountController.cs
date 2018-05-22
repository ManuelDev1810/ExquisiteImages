using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExquisiteImages.Models;
using Microsoft.AspNetCore.Identity;
using ExquisiteImages.Infrastructure.ImageClient;
using ExquisiteImages.Infrastructure.CommentClient;

namespace ExquisiteImages.Controllers
{
    public class AccountController : Controller
    {
        UserManager<AppUser> userManager;
        SignInManager<AppUser> signInManager;
        IImageClient imageClient;
        ICommentClient commentClient;
        public AccountController(UserManager<AppUser> ustManager, SignInManager<AppUser> signManager,
                                IImageClient imgClient, ICommentClient commClient)
        {
            userManager = ustManager;
            signInManager = signManager;
            imageClient = imgClient;
            commentClient = commClient;
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

        public async Task<IActionResult> Profile(string id)
        {
            AppUser user = null;
            
            if (id != null)
            {
                user = await userManager.FindByIdAsync(id);
            } else if(User.Identity.IsAuthenticated)
            {
                user = await userManager.FindByNameAsync(User.Identity.Name);
            }

            if (user == null)
                return NotFound();

            List<Image> Images = await imageClient.GetByUsers(user.Id);
            List<Comment> Comments = await commentClient.CommentsOfUser(user.Id);
            user.Images = Images;
            user.Comments = Comments;
            return View(user);
        }
    }
}
