using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExquisiteImagesApi.Services.Interfaces;
using ExquisiteImagesApi.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace ExquisiteImagesApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        IImageRepository imageRepository;
        public HomeController(IImageRepository imgRepo)
        {
            imageRepository = imgRepo;
        }

        [HttpGet]
        public List<Image> Get() => imageRepository.Images();

        [HttpPost]
        public async Task<Image> Create([FromBody] Image image)
        {
            Image model = await imageRepository.Create(image);
            return model;
        }

    }
}
