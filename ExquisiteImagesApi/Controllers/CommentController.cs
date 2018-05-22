using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExquisiteImagesApi.Models;
using ExquisiteImagesApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExquisiteImagesApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        ICommentRepository repository;
        public CommentController(ICommentRepository repo)
        {
            repository = repo;
        }

        [Route("{imgId}")]
        [HttpGet]
        public List<Comment> GetCommentsOfImages([FromRoute] int imgId)
        {
            List<Comment> comments = repository.CommentsOfImage(imgId);
            return comments;
        }

        [Route("userComments/{userId}")]
        [HttpGet]
        public List<Comment> GetCommentsOfUser([FromRoute] string userId)
        {
            List<Comment> comments = repository.CommentsOfUser(userId);
            return comments;
        }

        [HttpPost]
        public async Task<Comment> Create([FromBody] Comment model)
        {
            Comment comment = await repository.Create(model);
            return comment;
        }
    }
}
