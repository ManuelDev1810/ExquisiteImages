using ExquisiteImagesApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExquisiteImagesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExquisiteImagesApi.Services.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        ApplicationDbContext dbContext;
        public CommentRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public List<Comment> CommentsOfImage(int imgId)
        {
            return dbContext.Comments.Where(m => m.ImageId == imgId).ToList();
        }

        public List<Comment> CommentsOfUser(string userId)
        {
            return dbContext.Comments.Where(m => m.UserId == userId).ToList();
        }

        public async Task<Comment> Create(Comment model)
        {
            await dbContext.Comments.AddAsync(model);
            await dbContext.SaveChangesAsync();
            return model;
        }
    }
}
