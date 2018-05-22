using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExquisiteImages.Infrastructure.CommentClient;
using ExquisiteImages.Models;

namespace ExquisiteImages.Controllers
{
    public class CommentController : Controller
    {
        ICommentClient commentClient;
        public CommentController(ICommentClient commentClien)
        {
            commentClient = commentClien;
        }

        public async Task<IActionResult> Create(string commentContent,int imageId)
        {
            if (ModelState.IsValid)
            {
                Comment model = new Comment
                {
                    CommentContent = commentContent,
                    ImageId = imageId
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
