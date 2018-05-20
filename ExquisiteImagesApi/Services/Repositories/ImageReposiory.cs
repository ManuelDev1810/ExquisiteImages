using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExquisiteImagesApi.Services.Interfaces;
using ExquisiteImagesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExquisiteImagesApi.Services.Repositories
{
    public class ImageReposiory : IImageRepository
    {
        ApplicationDbContext context;
        public ImageReposiory(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        public List<Image> Images() => context.Images.Include(m => m.Comments).ToList();

        public List<Image> ImagesOfUser(string UserId)
        {
           return context.Images.Include(m => m.Comments).Where(m => m.UserId == UserId).ToList();
        }

        public async Task<Image> Image(int id)
        {
            Image image = await context.Images.Include(m => m.Comments).SingleOrDefaultAsync(m => m.ImageId == id);
            if(image != null)
            {
                return image;
            }
            return new Image { };
        }

        public async Task<Image> Create(Image image)
        {
            await context.Images.AddAsync(image);
            await context.SaveChangesAsync();
            return image;
        }

        public async Task<Image> Update(Image image)
        {
            context.Entry(image).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return image;
        }

        public async Task<Image> Delete(Image image)
        {
            context.Images.Remove(image);
            await context.SaveChangesAsync();
            return image;
        }
    }
}
