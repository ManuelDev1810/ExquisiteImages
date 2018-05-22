using ExquisiteImagesApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExquisiteImagesApi.Models;

namespace ExquisiteImagesApi.Services.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        ApplicationDbContext dbContext;
        public CommentRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public async Task<Comment> Create(Comment model)
        {
            try
            {
                await dbContext.Comments.AddAsync(model);
                await dbContext.SaveChangesAsync();
                return model;
            }catch(Exception e)
            {
                throw e;
            }
        }
    }
}
