using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExquisiteImages.Models;

namespace ExquisiteImages.Infrastructure.ImageClient
{
    public interface IImageClient
    {
        Task<List<Image>> Get();
    }
}
