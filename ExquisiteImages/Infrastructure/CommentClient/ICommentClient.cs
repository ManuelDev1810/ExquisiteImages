using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExquisiteImages.Models;

namespace ExquisiteImages.Infrastructure.CommentClient
{
    public interface ICommentClient
    {
        Task<List<Comment>> CommentsOfImg(int id);
        Task<List<Comment>> CommentsOfUser(string userId);
        Task<Comment> Create(Comment comment);
    }
}
