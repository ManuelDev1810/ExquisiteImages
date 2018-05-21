using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExquisiteImages.Infrastructure.ImageClient;
using ExquisiteImages.Models;
using Microsoft.AspNetCore.Identity;

namespace ExquisiteImages.Controllers
{
    public class ImageController : Controller
    {
        IImageClient imageClient;
        UserManager<AppUser> userManager;

        public ImageController(IImageClient imgClient, UserManager<AppUser> usrMgr)
        {
            imageClient = imgClient;
            userManager = usrMgr;
        }

        public async Task<ViewResult> Img(int id)
        {
            Image image = await imageClient.GetImg(id);
            ViewBag.User = await userManager.FindByIdAsync(image.UserId);
            return View(image);
        }
    }
}
