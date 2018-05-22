using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExquisiteImages.Infrastructure.ImageClient;
using ExquisiteImages.Models;
using Microsoft.AspNetCore.Identity;
using ExquisiteImages.Infrastructure.CommentClient;

namespace ExquisiteImages.Controllers
{
    public class ImageController : Controller
    {
        IImageClient imageClient;
        ICommentClient commentClient;
        UserManager<AppUser> userManager;

        public ImageController(IImageClient imgClient, ICommentClient comClient, UserManager<AppUser> usrMgr)
        {
            imageClient = imgClient;
            commentClient = comClient;
            userManager = usrMgr;
        }

        public async Task<ViewResult> Img(int id)
         {
            Image image = await imageClient.GetImg(id);
            image.Comments = await commentClient.CommentsOfImg(image.ImageId);
            ViewBag.User = await userManager.FindByIdAsync(image.UserId);
            return View(image);
        }
    }
}
