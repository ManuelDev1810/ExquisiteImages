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

        [HttpPost]
        public async Task<Comment> Create([FromBody] Comment model)
        {
            Comment comment = await repository.Create(model);
            return comment;
        }
    }
}
