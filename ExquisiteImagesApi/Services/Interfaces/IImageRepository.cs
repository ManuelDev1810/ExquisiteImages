using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExquisiteImagesApi.Models;

namespace ExquisiteImagesApi.Services.Interfaces
{
    public interface IImageRepository
    {
        List<Image> Images();
        Task<Image> Image(int id);
        Task<Image> Create(Image image);
        Task<Image> Update(Image image);
        Task<Image> Delete(Image image);
    }
}
