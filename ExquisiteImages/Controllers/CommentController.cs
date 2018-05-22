using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExquisiteImages.Infrastructure.CommentClient;
using ExquisiteImages.Models;
using Microsoft.AspNetCore.Identity;

namespace ExquisiteImages.Controllers
{
    public class CommentController : Controller
    {
        ICommentClient commentClient;
        UserManager<AppUser> userManager;

        public CommentController(ICommentClient commentClien, UserManager<AppUser> usrMgr)
        {
            commentClient = commentClien;
            userManager = usrMgr;
        }

        public async Task<IActionResult> Create(string commentContent,int imageId)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
                if (user == null)
                    return BadRequest();

                Comment model = new Comment
                {
                    CommentContent = commentContent,
                    ImageId = imageId,
                    UserId = user.Id,
                    Date = DateTime.Now
                };

                Comment comment = await commentClient.Create(model);
                if (comment != null)
                    return RedirectToAction("Img", "Image", new { id = comment.ImageId });
                else
                    BadRequest();
            }
            return BadRequest();
        }
    }
}
