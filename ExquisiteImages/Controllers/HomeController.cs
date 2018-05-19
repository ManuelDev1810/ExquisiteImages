using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using ExquisiteImages.Models;
using ExquisiteImages.Infrastructure.ImageClient;
using Microsoft.AspNetCore.Http;
using System.IO;

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

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Image model, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if(img != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", img.FileName);
                    using(var stream = new FileStream(path, FileMode.Create))
                    {
                        await img.CopyToAsync(stream);
                    }

                    model.Path = "/img/" + img.FileName;
                    Image image = await imageClient.Create(model);
                    if (image != null)
                        return RedirectToAction("Index");
                    else
                        return BadRequest(model);
                } else
                {
                    ModelState.AddModelError("", "Please select an Img");
                    return View(model);
                }
            } else
            {
                return View(model);
            }
        }
    }
}