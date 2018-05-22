using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExquisiteImages.Models;

namespace ExquisiteImages.Infrastructure.CommentClient
{
    public interface ICommentClient
    {
        Task<Comment> Create(Comment comment);
    }
}
