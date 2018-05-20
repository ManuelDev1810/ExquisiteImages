using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using ExquisiteImages.Models;
using ExquisiteImages.Infrastructure.ImageClient;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Identity;

namespace ExquisiteImages.Controllers
{
    public class HomeController : Controller
    {
        IImageClient imageClient;
        UserManager<AppUser> userManager;
        public HomeController(IImageClient imgClient, UserManager<AppUser> userMgr)
        {
            imageClient = imgClient;
            userManager = userMgr;
        }

        public async Task<IActionResult> Index()
        {
            List<Image> images = await imageClient.Get();
            return View(images);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Image model, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if(img != null)
                {
                    //Saving the img
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", img.FileName);
                    using(var stream = new FileStream(path, FileMode.Create))
                    {
                        await img.CopyToAsync(stream);
                    }

                    //Getting the current user
                    AppUser user = await userManager.FindByNameAsync(User.Identity.Name);

                    model.Path = "/img/" + img.FileName;
                    model.UserId = user.Id;

                    //Creating the Image
                    Image image = await imageClient.Create(model);
                    if (image != null)
                        return RedirectToAction("Index");
                    else
                        return BadRequest(model);
                } else
                {
                    ModelState.AddModelError("", "Please select an Img");
                    return View(model);
                }
            } else
            {
                return View(model);
            }
        }
    }
}