using ExquisiteImagesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExquisiteImagesApi.Services.Interfaces
{
    public interface ICommentRepository
    {
        
        //List<Comment> Comments();
        List<Comment> CommentsOfImage(int imgId);
        List<Comment> CommentsOfUser(string imgId);
        //Task<Comment> Image(int id);
        Task<Comment> Create(Comment model);
        //Task<Comment> Update(Comment image);
        //Task<Comment> Delete(Comment image);
    }
}
