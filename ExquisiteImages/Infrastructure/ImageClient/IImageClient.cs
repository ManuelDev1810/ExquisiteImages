using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExquisiteImages.Models;
using Microsoft.AspNetCore.Http;

namespace ExquisiteImages.Infrastructure.ImageClient
{
    public interface IImageClient
    {
        Task<List<Image>> Get();
        Task<Image> GetImg(int id);
        Task<List<Image>> GetByUsers(string UserId);
        Task<Image> Create(Image image);
    }
}
