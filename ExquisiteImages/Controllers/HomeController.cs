using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using ExquisiteImages.Models;
using ExquisiteImages.Infrastructure.ImageClient;

namespace ExquisiteImages.Controllers
{
    public class HomeController : Controller
    {
        IImageClient imageClient;
        public HomeController(IImageClient imgClient)
        {
            imageClient = imgClient;
        }

        public async Task<IActionResult> Index()
        {
            List<Image> images = await imageClient.Get();
            return View(images);
        }
    }
}